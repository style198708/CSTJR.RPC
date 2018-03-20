using CSTJR.Enum;
using CSTJR.Product.Entity.DBEntity;
using CSTJR.Product.Entity.ViewEntity;
using CSTJR.RPC.Product.Contracts;
using DMSFrame;
using System.Collections.Generic;
using System.Linq;
using TYSystem.BaseFramework.Common;
using TYSystem.BaseFramework.Common.Enum;
using TYSystem.BaseFramework.Common.Extension;

namespace CSTJR.RPC.Product
{
    public class RProductService : ProductService.Iface
    {
        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <param name="param"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public List<ProductListResult> GetProductList(SearchProductParam param)
        {
            if ((param.ProductIDs == null || param.ProductIDs.Count <= 0) && (param.MemberNames == null || param.MemberNames.Count <= 0))
            {
                return new List<ProductListResult>();
            }

            List<ProductListResult> dataList = new List<ProductListResult>();
            WhereClip<Pro_ProductBaseMST> where = new WhereClip<Pro_ProductBaseMST>();
            where.And(q => q.DeleteFlag == false && q.StatusFlag == EnumProStatusFlag.Publish);
            if (!param.ProductIDs.IsNullOrEmpty())
            {
                where.And(q => q.ProductID.Value.In(param.ProductIDs));
            }
            if (!string.IsNullOrEmpty(param.MemberName))
            {
                where.And(q => q.MemberName == param.MemberName);
            }
            if (!param.MemberNames.IsNullOrEmpty())
            {
                where.And(q => q.MemberName.In(param.MemberNames));
            }

            List<Pro_ProductBaseMST> resultList = DMS.Create<Pro_ProductBaseMST>()
           .Where(where)
           .OrderBy(q => q.OrderBy(q.CreateTime.Desc()))
           .ToList();

            if (resultList != null && resultList.Count > 0)
            {
                //私募股权，阳光私募，私募债权，信托，资管
                List<int?> peIDs = resultList.Where(q => q.ProductType == EnumProProductType.PE
                || q.ProductType == EnumProProductType.SunshinePrivate
                || q.ProductType == EnumProProductType.PrivateDebt
                || q.ProductType == EnumProProductType.Trust
                || q.ProductType == EnumProProductType.Asset).Select(q => q.ProductID).ToList();

                //保险
                List<int?> insuranceIDs = resultList.Where(q => q.ProductType == EnumProProductType.Insurance).Select(q => q.ProductID).ToList();
                //银行
                List<int?> bankIDs = resultList.Where(q => q.ProductType == EnumProProductType.Bank).Select(q => q.ProductID).ToList();

                #region  私募股权，阳光私募，私募债权，信托，资管
                if (peIDs.Count > 0)
                {
                    #region where
                    WhereClip<vw_Pro_ProductMSTInfo> productWhere = new WhereClip<vw_Pro_ProductMSTInfo>();
                    productWhere.And(q => q.ProductID.In(peIDs));
                    #endregion

                    List<vw_Pro_ProductMSTInfo> productList = DMS.Create<vw_Pro_ProductMSTInfo>()
                         .Where(productWhere)
                         .ToList();
                    if (productList != null && productList.Count > 0)
                    {
                        foreach (vw_Pro_ProductMSTInfo item in productList)
                        {
                            ProductListResult entity = new ProductListResult()
                            {
                                ProductID = item.ProductID.ToInt(),
                                ProductName = item.ProductName,
                                ProductType = item.ProductType.Value,
                                CategoryName = item.CategoryName,
                                CodeName = item.CodeName,
                                ProductStatusType = EnumBase.GetDescription(typeof(EnumProductStatusType), item.ProductStatusType),
                                FundLogo = DomainManageConfigInfo.ImgServerUrl + EnumSysImageDir.FUNDLOGO + item.FundLogo,
                                CompanyName = item.FundName,
                                MemberName = item.MemberName,
                                CreateTime = item.CreateTime.ToString(),

                                ExtStr01 = "年化收益",
                                ExtVaule01 = item.IncomeRange1.Value.ToString("#0.##") + "%",//固定

                                ExtStr02 = "返佣比例",
                                ExtVaule02 = item.BonusRatio.Value.ToString("#0.##") + "%",

                                ExtStr03 = "投资期限",
                                ExtVaule03 = item.ProductTerm + EnumBase.GetDescription(typeof(EnumTermUnit), item.TermUnit),

                                ExtStr04 = "起投金额",
                                ExtVaule04 = item.InvestmentStart.Value.ToString("N0") + "万",
                            };
                            if (item.IncomeType == EnumIncomeType.FixedFloat)
                            {
                                //固定+浮动
                                entity.ExtVaule01 = item.IncomeRange1.Value.ToString("#0.##") + "%+浮动";
                            }
                            else if (item.IncomeType == EnumIncomeType.Float)
                            {
                                //浮动
                                entity.ExtVaule01 = "浮动";
                            }

                            if (!param.IsLogin)
                            {
                                //未登录
                                if (item.ProductType.Value == EnumProProductType.PE || item.ProductType.Value == EnumProProductType.SunshinePrivate || item.ProductType.Value == EnumProProductType.PrivateDebt)
                                {
                                    entity.ExtVaule01 = "认定可见";
                                }

                            }
                            dataList.Add(entity);
                        }
                    }
                }
                #endregion

                #region 银行产品
                if (bankIDs.Count > 0)
                {
                    #region where
                    WhereClip<vw_Pro_BankProductMSTInfo> bankeWhere = new WhereClip<vw_Pro_BankProductMSTInfo>();
                    bankeWhere.And(q => q.ProductID.In(bankIDs));
                    #endregion

                    List<vw_Pro_BankProductMSTInfo> bankProductList = DMS.Create<vw_Pro_BankProductMSTInfo>()
                        .Where(bankeWhere)
                        .ToList();
                    if (bankProductList != null && bankProductList.Count > 0)
                    {
                        foreach (vw_Pro_BankProductMSTInfo item in bankProductList)
                        {
                            ProductListResult entity = new ProductListResult()
                            {
                                ProductID = item.ProductID.ToInt(),
                                ProductName = item.ProductName,
                                ProductType = item.ProductType.Value,
                                CategoryName = item.CategoryName,
                                CodeName = item.CodeName,
                                ProductStatusType = EnumBase.GetDescription(typeof(EnumProductStatusType), item.ProductStatusType),
                                FundLogo = DomainManageConfigInfo.ImgServerUrl + EnumSysImageDir.FUNDLOGO + item.FundLogo,
                                CompanyName = item.FundName,
                                MemberName = item.MemberName,
                                CreateTime = item.CreateTime.ToString(),

                                ExtStr01 = "年化收益",
                                ExtVaule01 = item.ExpectYearEarnings.Value.ToString("#0.##") + "%",//固定

                                ExtStr02 = "返佣比例",
                                ExtVaule02 = item.BonusRatio.Value.ToString("#0.##") + "%",

                                ExtStr03 = "投资期限",
                                ExtVaule03 = item.InvestmentTime + EnumBase.GetDescription(typeof(EnumTermUnit), item.InvestmentTimeUnit),

                                ExtStr04 = "起投金额",
                                ExtVaule04 = item.PurchaseRequire.Value.ToString("N0") + "元",

                            };
                            if (item.IncomeType == EnumIncomeType.FixedFloat)
                            {
                                //固定+浮动
                                entity.ExtVaule01 = item.ExpectYearEarnings.Value.ToString("#0.##") + "%+浮动";
                            }
                            else if (item.IncomeType == EnumIncomeType.Float)
                            {
                                //浮动
                                entity.ExtVaule01 = "浮动";
                            }
                            dataList.Add(entity);
                        }
                    }
                }
                #endregion

                #region 保险产品
                if (insuranceIDs.Count > 0)
                {
                    #region where
                    WhereClip<vw_Pro_InsureMSTInfo> insuranceWhere = new WhereClip<vw_Pro_InsureMSTInfo>();
                    insuranceWhere.And(q => q.ProductID.In(insuranceIDs));
                    #endregion

                    List<vw_Pro_InsureMSTInfo> insuranceList = DMS.Create<vw_Pro_InsureMSTInfo>()
                        .Where(insuranceWhere)
                        .ToList();
                    if (insuranceList != null && insuranceList.Count > 0)
                    {
                        foreach (vw_Pro_InsureMSTInfo item in insuranceList)
                        {
                            ProductListResult entity = new ProductListResult()
                            {
                                ProductID = item.ProductID.ToInt(),
                                ProductName = item.ProductName,
                                ProductType = item.ProductType.Value,
                                CategoryName = item.CategoryName,
                                CodeName = item.CodeName,
                                ProductStatusType = EnumBase.GetDescription(typeof(EnumProductStatusType), item.ProductStatusType),
                                FundLogo = DomainManageConfigInfo.ImgServerUrl + EnumSysImageDir.FUNDLOGO + item.FundLogo,
                                CompanyName = item.FundName,
                                MemberName = item.MemberName,
                                CreateTime = item.CreateTime.ToString(),

                                ExtStr01 = "保额",
                                ExtVaule01 = item.InsuredSum,

                                ExtStr02 = "返佣比例",
                                ExtVaule02 = item.BonusRatio.Value.ToString("#0.##") + "%",

                                ExtStr03 = "保障期限",
                                ExtVaule03 = item.InsureTime,

                                ExtStr04 = "起投金额",
                                ExtVaule04 = "",
                            };
                            dataList.Add(entity);
                        }
                    }
                }
                #endregion
            }
            return dataList.OrderByDescending(p => p.CreateTime).ToList();
        }

        /// <summary>
        /// 获取机构列表
        /// </summary>
        /// <param name="fundIDs"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public List<ProductFundCompanyResult> GetProductFundCompanyList(List<int> fundIDs)
        {
            if (fundIDs == null || fundIDs.Count <= 0)
            {
                return null;
            }
            List<ProductFundCompanyResult> resultList = new List<ProductFundCompanyResult>();
            List<Pro_FundCompany> fundList = DMS.Create<Pro_FundCompany>().Where(q => q.FundID.Value.In(fundIDs)).ToList();
            foreach (var item in fundList)
            {
                ProductFundCompanyResult entity = new ProductFundCompanyResult()
                {
                    FundID = item.FundID.ToInt(),
                    FundName = item.FundName,
                    FundLogo = item.FundLogo,
                    FundDesc = item.FundDesc,
                };
                resultList.Add(entity);
            }
            return resultList;
        }
    }
}
