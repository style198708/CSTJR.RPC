using CSTJR.Enum;
using CSTJR.Member.Entity.DBEntity;
using CSTJR.RPC.Member.Contracts;
using DMSFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using TYSystem.BaseFramework.Common;
using TYSystem.BaseFramework.Common.Enum;
using TYSystem.BaseFramework.Common.Extension;
using TYSystem.BaseFramework.Common.Helper;

namespace CSTJR.RPC.Member
{
    /// <summary>
    /// 会员RPC接口
    /// </summary>
    public class RMemberService : MemberService.Iface
    {
        /// <summary>
        /// 通过用户ID或手机号查询用户基本信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public UserInfoResult GetUserInfo(string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                return null;
            }
            Mem_MemberAccount account = DMS.Create<Mem_MemberAccount>()
                .Where(q => (q.Mobile == userID || q.MemberName == userID) && q.StatusFlag == EnumStatusFlag.Passed)
                .FirstOrDefault();
            if (account == null) 
            {
                return null;
            }
            UserInfoResult userInfo = new UserInfoResult();
            //userInfo.MemberID = account.MemberName;
            userInfo.Logo = DomainManageConfigInfo.ImgServerUrl + (string.IsNullOrEmpty(account.Logo) ? EnumSysImageDir.MEMBERLOGO + "default.png" : EnumSysImageDir.MEMBERLOGO + account.Logo);
            if (!string.IsNullOrEmpty(account.Logo))
            {
                if (account.Logo.ToLower().StartsWith("http://") || account.Logo.ToLower().StartsWith("https://"))
                {
                    userInfo.Logo = account.Logo;
                }
            }
            userInfo.MemberName = account.MemberName;
            userInfo.NickName = account.NickName;
            userInfo.TrueName = string.IsNullOrEmpty(account.TrueName) ? "" : account.TrueName;
            userInfo.SexType = EnumBase.GetDescription(typeof(EnumMemSexType), account.SexType);
            userInfo.MemberType = EnumBase.GetDescription(typeof(EnumMemMemberType), account.MemberType);
            userInfo.ShortIntroduction = string.IsNullOrEmpty(userInfo.ShortIntroduction) ? "" : userInfo.ShortIntroduction;
            userInfo.Area = GetProvinceAndCity(account.AreaNamePath);
            userInfo.IsCognizance = account.IsCognizance.ToBool();
            userInfo.Email = string.IsNullOrEmpty(account.Email) ? "" : account.Email;
            userInfo.Mobile = account.Mobile;


            return userInfo;
        }

        /// <summary>
        /// 通过用户ID或手机号查询理财师基本信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public PlannerInfoResult GetPlannerInfo(string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
               
                return null;
            }
            Mem_MemberAccount account = DMS.Create<Mem_MemberAccount>()
                .Where(q => (q.Mobile == userID || q.MemberName == userID) && q.StatusFlag == EnumStatusFlag.Passed)
                .FirstOrDefault();
            if (account == null)
            {
               
                return null;
            }

            Mem_MemberPlanner planner = DMS.Create<Mem_MemberPlanner>().Where(q => q.MemberName == userID && q.PlannerStatusFlag == EnumMemPlannerStatusFlag.Passed).FirstOrDefault();
            if (planner == null)
            {
                
                return null;
            }
            Mem_MemberPlannerLevel plevel = DMS.Create<Mem_MemberPlannerLevel>()
                .Where(q => q.Level == planner.PlannerLevel && q.StatusFlag == EnumStatusFlag.Passed).FirstOrDefault();
            int? Level = 0;
            string LevelName = "";
            if (plevel != null)
            {
                Level = plevel.Level;
                LevelName = plevel.LevelName;
            }
            PlannerInfoResult userInfo = new PlannerInfoResult();
            //  userInfo.MemberID = account.MemberName;
            userInfo.Logo = DomainManageConfigInfo.ImgServerUrl + (string.IsNullOrEmpty(account.Logo) ? EnumSysImageDir.MEMBERLOGO + "default.png" : EnumSysImageDir.MEMBERLOGO + account.Logo);
            if (!string.IsNullOrEmpty(account.Logo))
            {
                if (account.Logo.ToLower().StartsWith("http://") || account.Logo.ToLower().StartsWith("https://"))
                {
                    userInfo.Logo = account.Logo;
                }
            }
            userInfo.MemberName = account.MemberName;
            userInfo.NickName = account.NickName;
            userInfo.TrueName = string.IsNullOrEmpty(account.TrueName) ? "" : account.TrueName;
            userInfo.SexType = EnumBase.GetDescription(typeof(EnumMemSexType), account.SexType);
            userInfo.MemberType = EnumBase.GetDescription(typeof(EnumMemMemberType), account.MemberType);
            userInfo.ShortIntroduction = string.IsNullOrEmpty(account.ShortIntroduction) ? "" : account.ShortIntroduction;
            userInfo.Area = GetProvinceAndCity(account.AreaNamePath);
            userInfo.Mobile = account.Mobile;
            userInfo.Email = string.IsNullOrEmpty(account.Email) ? "" : account.Email;
            userInfo.CompanyName = string.IsNullOrEmpty(planner.CompanyName) ? "" : planner.CompanyName;
            userInfo.Title = string.IsNullOrEmpty(planner.PlannerTitle) ? "" : planner.PlannerTitle;
            userInfo.IDNo = string.IsNullOrEmpty(planner.IDCard) ? "" : planner.IDCard;
            userInfo.WorkYears = EnumBase.GetDescription(typeof(EnumMemWorkYearFlag), planner.PlannerWorkYears) + "从业经验";
            userInfo.Level = Level.ToInt();
            userInfo.LevelName = LevelName;
            userInfo.ApplyTime = planner.PlannerApplyTime.Value.ToString("yyyy-MM-dd");
            userInfo.VerifyTime = planner.PlannerVerifyTime.Value.ToString("yyyy-MM-dd");
            if (planner.PlannerStatusFlag == EnumMemPlannerStatusFlag.Pending)
            {
                userInfo.Status = EnumBase.GetDescription(typeof(EnumMemPlannerStatusFlag), EnumMemPlannerStatusFlag.Pending);
            }
            if (planner.PlannerStatusFlag == EnumMemPlannerStatusFlag.UnPassed)
            {
                userInfo.Status = EnumBase.GetDescription(typeof(EnumMemPlannerStatusFlag), EnumMemPlannerStatusFlag.UnPassed);

            }
            if (planner.PlannerStatusFlag == EnumMemPlannerStatusFlag.Passed)
            {
                userInfo.Status = EnumBase.GetDescription(typeof(EnumMemPlannerStatusFlag), EnumMemPlannerStatusFlag.Passed);
            }
            userInfo.StatusRemark = string.IsNullOrEmpty(planner.PlannerStatusRemark) ? "" : planner.PlannerStatusRemark;

            return userInfo;
        }

        ///// <summary>
        ///// 通过用户手机号查询理财师基本信息
        ///// </summary>
        ///// <param name="mobile"></param>
        ///// <param name="errMsg"></param>
        ///// <returns></returns>
        //public PlannerInfoResult GetPlannerInfo(string mobile, ref string errMsg)
        //{
        //    if (string.IsNullOrEmpty(mobile))
        //    {
        //        errMsg = "手机不能为空";
        //        return null;
        //    }
        //    Mem_MemberAccount account = DMS.Create<Mem_MemberAccount>()
        //        .Where(q => q.Mobile == mobile && q.StatusFlag == EnumStatusFlag.Passed && q.DeleteFlag == false)
        //        .FirstOrDefault();
        //    if (account == null)
        //    {
        //        errMsg = "未找到会员信息";
        //        return null;
        //    }

        //    Mem_MemberPlanner planner = DMS.Create<Mem_MemberPlanner>().Where(q => q.MemberID == account.MemberID && q.PlannerStatusFlag == EnumMemPlannerStatusFlag.Passed).FirstOrDefault();
        //    if (planner == null)
        //    {
        //        errMsg = "未找到会员信息";
        //        return null;
        //    }
        //    Mem_MemberPlannerLevel plevel = DMS.Create<Mem_MemberPlannerLevel>()
        //        .Where(q => q.Level == planner.PlannerLevel && q.StatusFlag == EnumStatusFlag.Passed).FirstOrDefault();
        //    int? Level = 0;
        //    string LevelName = "";
        //    if (plevel != null)
        //    {
        //        Level = plevel.Level;
        //        LevelName = plevel.LevelName;
        //    }
        //    PlannerInfoResult userInfo = new PlannerInfoResult();
        //    userInfo.MemberID = account.MemberID;
        //    userInfo.Logo = DomainManageConfigInfo.ImgServerUrl + (string.IsNullOrEmpty(account.Logo) ? EnumSysImageDir.AppIMAGE + "default.png" : EnumSysImageDir.MEMBERLOGO + account.Logo);
        //    if (!string.IsNullOrEmpty(account.Logo))
        //    {
        //        if (account.Logo.ToLower().StartsWith("http://") || account.Logo.ToLower().StartsWith("https://"))
        //        {
        //            userInfo.Logo = account.Logo;
        //        }
        //    }
        //    userInfo.MemberName = account.MemberName;
        //    userInfo.NickName = account.NickName;
        //    userInfo.TrueName = string.IsNullOrEmpty(account.TrueName) ? "" : account.TrueName;
        //    userInfo.SexType = EnumBase.GetDescription(typeof(EnumMemSexType), account.SexType);
        //    userInfo.MemberType = EnumBase.GetDescription(typeof(EnumMemMemberType), account.MemberType);
        //    userInfo.ShortIntroduction = string.IsNullOrEmpty(account.ShortIntroduction) ? "" : account.ShortIntroduction;
        //    userInfo.Area = GetProvinceAndCity(account.AreaNamePath);
        //    userInfo.Mobile = account.Mobile;
        //    userInfo.Email = string.IsNullOrEmpty(account.Email) ? "" : account.Email;
        //    userInfo.CompanyName = string.IsNullOrEmpty(planner.CompanyName) ? "" : planner.CompanyName;
        //    userInfo.Title = string.IsNullOrEmpty(planner.PlannerTitle) ? "" : planner.PlannerTitle;
        //    userInfo.IDNo = string.IsNullOrEmpty(planner.IDCard) ? "" : planner.IDCard;
        //    userInfo.WorkYears = EnumBase.GetDescription(typeof(EnumMemWorkYearFlag), planner.PlannerWorkYears) + "从业经验";
        //    userInfo.Level = Level;
        //    userInfo.LevelName = LevelName;
        //    userInfo.ApplyTime = planner.PlannerApplyTime.Value.ToString("yyyy-MM-dd");
        //    userInfo.VerifyTime = planner.PlannerVerifyTime.Value.ToString("yyyy-MM-dd");
        //    if (planner.PlannerStatusFlag == EnumMemPlannerStatusFlag.Pending)
        //    {
        //        userInfo.Status = EnumBase.GetDescription(typeof(EnumMemPlannerStatusFlag), EnumMemPlannerStatusFlag.Pending);
        //    }
        //    if (planner.PlannerStatusFlag == EnumMemPlannerStatusFlag.UnPassed)
        //    {
        //        userInfo.Status = EnumBase.GetDescription(typeof(EnumMemPlannerStatusFlag), EnumMemPlannerStatusFlag.UnPassed);

        //    }
        //    if (planner.PlannerStatusFlag == EnumMemPlannerStatusFlag.Passed)
        //    {
        //        userInfo.Status = EnumBase.GetDescription(typeof(EnumMemPlannerStatusFlag), EnumMemPlannerStatusFlag.Passed);
        //    }
        //    userInfo.StatusRemark = string.IsNullOrEmpty(planner.PlannerStatusRemark) ? "" : planner.PlannerStatusRemark;

        //    //处理运营账号的消息
        //    List<string> mobileList = MobileList();
        //    if (mobileList != null && mobileList.Contains(userInfo.Mobile))
        //    {
        //        userInfo.Mobile = EnumOfficialUser.TA;
        //    }

        //    return userInfo;
        //}

        /// <summary>
        /// 通过用户ID 批量查询用户基本信息
        /// </summary>
        /// <param name="userIDs"></param>
        /// <returns></returns>
        public List<UserInfoResult> GetUserInfoBatch(List<string> userIDs)
        {
            if (userIDs == null || userIDs.Count <= 0)
            {
                return null;
            }
            List<Mem_MemberAccount> accounts = DMS.Create<Mem_MemberAccount>()
                .Where(q => q.MemberName.In(userIDs) && q.StatusFlag == EnumStatusFlag.Passed).ToList();
            if (accounts == null || accounts.Count <= 0)
            {
                return null;
            }

            //运营账号
            List<string> mobileList = MobileList();

            List<UserInfoResult> userList = new List<UserInfoResult>();
            string Logop = string.Empty;
            accounts.ForEach(q =>
            {

                if (q.Logo.ToLower().StartsWith("http://") || q.Logo.ToLower().StartsWith("https://"))
                {
                    Logop = q.Logo;
                }
                else
                {
                    Logop = DomainManageConfigInfo.ImgServerUrl + (string.IsNullOrEmpty(q.Logo) ? EnumSysImageDir.MEMBERLOGO + "default.png" : EnumSysImageDir.MEMBERLOGO + q.Logo);
                }


                userList.Add(new UserInfoResult
                {
                    // MemberID = q.MemberID,
                    // Logo = DomainManageConfigInfo.ImgServerUrl + (string.IsNullOrEmpty(q.Logo) ? EnumSysImageDir.AppIMAGE + "default.png" : EnumSysImageDir.MEMBERLOGO + q.Logo),
                    Logo = Logop,
                    MemberName = q.MemberName,
                    NickName = q.NickName,
                    TrueName = q.TrueName,
                    SexType = EnumBase.GetDescription(typeof(EnumMemSexType), q.SexType),
                    MemberType = EnumBase.GetDescription(typeof(EnumMemMemberType), q.MemberType),
                    ShortIntroduction = q.ShortIntroduction,
                    Area = GetProvinceAndCity(q.AreaNamePath),
                    Mobile = string.Empty,
                    Email = q.Email,
                    IsCognizance = q.IsCognizance.ToBool(),
                });

            });
            return userList;
        }

        /// <summary>
        /// 通过用户ID 批量查询理财师基本信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<PlannerInfoResult> GetPlannerInfoBatch(List<string> userIDs)
        {
            if (userIDs == null || userIDs.Count <= 0)
            {
                return null;
            }
            List<Mem_MemberPlanner> plannerList = DMS.Create<Mem_MemberPlanner>()
                .Where(q => q.MemberName.In(userIDs) && q.PlannerStatusFlag == EnumMemPlannerStatusFlag.Passed).ToList();
            if (plannerList == null || plannerList.Count <= 0)
            {
                return null;
            }
            string[] memberIds = plannerList.Select(q => q.MemberName).ToArray();
            if (memberIds == null || memberIds.Length <= 0)
            {
                return null;
            }
            List<Mem_MemberAccount> memberList = DMS.Create<Mem_MemberAccount>()
                .Where(q => q.MemberName.In(memberIds) && q.StatusFlag == EnumStatusFlag.Passed).ToList();
            List<Mem_MemberPlannerLevel> levelList = DMS.Create<Mem_MemberPlannerLevel>().Where(q => q.StatusFlag == EnumStatusFlag.Passed).ToList();
            List<PlannerInfoResult> userList = new List<PlannerInfoResult>();
            //运营账号
            List<string> mobileList = MobileList();
            plannerList.ForEach(q =>
            {
                PlannerInfoResult userInfo = new PlannerInfoResult();
                Mem_MemberAccount memberEntity = memberList.Where(k => k.MemberName == q.MemberName).FirstOrDefault();
                if (memberEntity != null)
                {
                    int? Level = 0;
                    string LevelName = "";
                    Mem_MemberPlannerLevel levelEntity = levelList.Where(t => t.Level == q.PlannerLevel).FirstOrDefault();
                    if (levelEntity != null)
                    {
                        Level = levelEntity.Level;
                        LevelName = levelEntity.LevelName;
                    }

                    string LogoP = string.Empty;
                    if (memberEntity.Logo.ToLower().StartsWith("http://") || memberEntity.Logo.ToLower().StartsWith("https://"))
                    {
                        LogoP = memberEntity.Logo;
                    }
                    else
                    {
                        LogoP = string.IsNullOrEmpty(memberEntity.Logo) ? FileHelper.GetThumbnailPath("default.png", EnumSysImageDir.MEMBERLOGO) : FileHelper.GetThumbnailPath(memberEntity.Logo, EnumSysImageDir.MEMBERLOGO);
                    }



                    userList.Add(new PlannerInfoResult
                    {
                        // MemberID = q.MemberID,
                        Logo = LogoP,
                        MemberName = memberEntity.MemberName,
                        NickName = memberEntity.NickName,
                        TrueName = memberEntity.TrueName,
                        SexType = EnumBase.GetDescription(typeof(EnumMemSexType), memberEntity.SexType),
                        MemberType = EnumBase.GetDescription(typeof(EnumMemMemberType), memberEntity.MemberType),
                        ShortIntroduction = memberEntity.ShortIntroduction,
                        Area = GetProvinceAndCity(memberEntity.AreaNamePath),
                        Mobile = string.Empty,
                        Email = memberEntity.Email,
                        CompanyName = q.CompanyName,
                        Title = q.PlannerTitle,
                        IDNo = q.IDCard,
                        WorkYears = EnumBase.GetDescription(typeof(EnumMemWorkYearFlag), q.PlannerWorkYears),
                        Level = Level.ToInt(),
                        LevelName = LevelName,
                        ApplyTime = q.PlannerApplyTime.Value.ToString("yyyy-MM-dd"),
                        VerifyTime = q.PlannerVerifyTime.Value.ToString("yyyy-MM-dd"),
                        Status = EnumBase.GetDescription(typeof(EnumMemPlannerStatusFlag), q.PlannerStatusFlag),
                        StatusRemark = q.PlannerStatusRemark,
                        RegistTime = memberEntity.CreateTime.Value.ToString("yyyy年MM月") + "入驻",
                    });
                }
            });

            return userList;
        }

        /// <summary>
        /// 获取相应会员印象 数字
        /// </summary>
        /// <param name = "userID" ></ param >
        /// < returns ></ returns >
        public List<MemberImpressResult> GetMemberImpressList(string userID)
        {
            List<MemberImpressResult> impress = new List<MemberImpressResult>();
            if (!string.IsNullOrEmpty(userID))
            {
                impress = DMS.Create<Mem_MemberImpress>()
                        .Where(q => q.RelationName == userID && q.DeleteFlag == false)
                        .OrderBy(q => q.OrderBy(q.CreateTime.Desc()))
                        .GroupBy(q => q.ImpressContent).Select(p => new MemberImpressResult() { ImpressContent = p.Key, Count = p.Count() }).ToList();
            }
            return impress;
        }

        /// <summary>
        /// 更新用户积分
        /// </summary>
        /// <param name="param"></param>
        public void UpdateMemberIntegral(string userID, string userName, int integralSource, int payOutIn)
        {
            if (string.IsNullOrEmpty(userID) || integralSource == 0 || payOutIn == 0)
            {
                return;
            }

            //积分来源类型  从枚举EnumMemIntegralType
            //认证类
            int?[] verifyType = {
                EnumMemIntegralType.UploadLogo,
                EnumMemIntegralType.VerifyEmail,
                EnumMemIntegralType.VerifyMobile,
                EnumMemIntegralType.SignupWallet,
                EnumMemIntegralType.ApplyPlanner
            };
            //社交类
            List<int> socialType =new List<int> {
                EnumMemIntegralType.Signin,
                EnumMemIntegralType.Dynamic,
                EnumMemIntegralType.Comment,
                EnumMemIntegralType.Fabulous,
                EnumMemIntegralType.RedPacket,
                EnumMemIntegralType.Forward,
                EnumMemIntegralType.Impress,
                EnumMemIntegralType.ShareAPP,
                EnumMemIntegralType.FabulousBy,
                EnumMemIntegralType.ForwardBy,
                EnumMemIntegralType.CommentBy,
                EnumMemIntegralType.Invite};
            //发布产品
            List<int> AddProductType =new List<int> { EnumMemIntegralType.AddProduct };

          
            //用户今日获得的积分总数
            int? todayIntegralCount = 0;
            int? currentIntegral = 0;
            string remark = "";
            //社交类 每天积100分
            if (integralSource.In(socialType) && payOutIn == 1)
            {
                todayIntegralCount = TodayIntegral(userID, socialType);
            }
            //发布产品 每天积100分
            if (integralSource == EnumMemIntegralType.AddProduct && payOutIn == 1)
            {
                todayIntegralCount = TodayIntegral(userID, AddProductType);
            }
            //互动类日总积分上限100，发布产品日总积分上限100
            // 最后一次加积分超过100分 全加
            if (todayIntegralCount >= 100)
            {
               
                return;
            }

            if (payOutIn == 1)
            {
                Mem_MemberIntegral walletIntegral = DMS.Create<Mem_MemberIntegral>().Where(q => q.MemberName == userID && q.IntegralSource == integralSource && q.PayOutIn == 1).FirstOrDefault();
                if (walletIntegral != null && (integralSource == EnumMemIntegralType.UploadLogo || integralSource == EnumMemIntegralType.VerifyMobile || integralSource == EnumMemIntegralType.SignupWallet || integralSource == EnumMemIntegralType.ApplyPlanner))
                {
                  
                    return;
      
                }
                if (integralSource == EnumMemIntegralType.Signin)
                {
                    int? integralStart = 2;
                    int? maxIntegral = 10;
                    //获取上一次签到信息
                    Mem_MemberSignIn SignInEntity = DMS.Create<Mem_MemberSignIn>().Where(q => q.MemberName == userID).OrderBy(q => q.OrderBy(q.CreateTime.Desc())).FirstOrDefault();
                    if (SignInEntity == null)
                    {
                        //首次签到
                        currentIntegral = integralStart;
                    }
                    else
                    {
                        DateTime dateLast = (DateTime)SignInEntity.CreateTime;
                        DateTime dateToday = DateTime.Now.Date;
                        TimeSpan ts = dateToday - dateLast.Date;
                        if (ts.Days < 0)
                        {
                          
                            return;
                        }
                        if (ts.Days == 0)
                        {
  
                            return;
                        }
                        if (ts.Days > 1)
                        {
                            //此次签到与前次签到时间差超过一天，则非连续签到，只计2分
                            currentIntegral = integralStart;
                        }
                        else if (ts.Days == 1)
                        {
                            //连续签到,积分最高10分
                            integralStart = integralStart * SignInEntity.ContinueTotalSign + 2;
                            currentIntegral = integralStart >= maxIntegral ? 10 : integralStart;
                        }
                    }
                    remark = "签到";
                }
                switch (integralSource)
                {
                    //签到需要单独处理
                    case EnumMemIntegralType.UploadLogo: currentIntegral = 20; remark = "首次上传头像"; break;//首次上传头像 增加20积分
                    case EnumMemIntegralType.VerifyEmail: currentIntegral = 20; remark = "首次验证邮箱"; break;//首次验证邮箱 增加20积分
                    case EnumMemIntegralType.VerifyMobile: currentIntegral = 20; remark = "首次验证邮箱"; break;//首次手机认证 增加20积分
                    case EnumMemIntegralType.SignupWallet: currentIntegral = 20; remark = "开通钱包并绑卡"; break;//开通钱包并绑卡 增加20积分
                    case EnumMemIntegralType.ApplyPlanner: currentIntegral = 30; remark = "理财师认证"; break;//理财师认证 增加30积分
                    case EnumMemIntegralType.Dynamic: currentIntegral = 10; remark = "发布动态"; break;//发布动态 增加10积分
                    case EnumMemIntegralType.Comment: currentIntegral = 5; remark = "发表评论"; break;//发表评论 增加5积分
                    case EnumMemIntegralType.Fabulous: currentIntegral = 2; remark = "点赞"; break;//点赞 增加2积分
                    case EnumMemIntegralType.Forward: currentIntegral = 5; remark = "转发动态"; break;//转发动态 增加5积分
                    case EnumMemIntegralType.Impress: currentIntegral = 20; remark = "给他人印象"; break;//主动给他人印象 增加20积分
                    case EnumMemIntegralType.ShareAPP: currentIntegral = 10; remark = "分享app"; break;//分享app 增加10积分
                    case EnumMemIntegralType.FabulousBy: currentIntegral = 2; remark = "被点赞"; break;//被点赞 增加2积分
                    case EnumMemIntegralType.ForwardBy: currentIntegral = 2; remark = "被转发"; break;//被转发 增加2积分
                    case EnumMemIntegralType.CommentBy: currentIntegral = 2; remark = "被评论"; break;//被评论 增加2积分
                    case EnumMemIntegralType.Invite: currentIntegral = 50; remark = "邀请"; break;//邀请好友 增加50积分
                    case EnumMemIntegralType.AddProduct: currentIntegral = 50; remark = "产品成功上线"; break;//发布产品被成功审核 增加50积分
                }

                int? totalIntegral = 0;
                Mem_MemberIntegral memberIntegral = DMS.Create<Mem_MemberIntegral>().Where(p => p.MemberName == userID).OrderBy(q => q.OrderBy(q.CreateTime.Desc())).FirstOrDefault();
                if (memberIntegral != null)
                {
                    totalIntegral = memberIntegral.TotalIntegral + currentIntegral;
                }
                else
                {
                    totalIntegral = currentIntegral;
                }
                Mem_MemberIntegral entity = new Mem_MemberIntegral()
                {
                    //IntegralKey = Guid.NewGuid(),
                    //MemberID = userID,
                    MemberName = string.IsNullOrEmpty(userName) ? string.Empty : userName,
                    CurrentIntegral = currentIntegral,
                    IntegralSource = integralSource,
                    TotalIntegral = totalIntegral,
                    PayOutIn = payOutIn,
                    Remark = remark,
                    CreateTime = DateTime.Now
                };
                DMS.Create<Mem_MemberIntegral>().Insert(entity);
                //根据总积分更改理财师等级
                int? integralCount = IntegralCount(userID);
                if (integralCount >= 12001)
                {
                    DMS.Create<Mem_MemberPlanner>().Edit(new Mem_MemberPlanner
                    {
                        PlannerLevel = 5,
                    }, q => q.MemberName == userID && q.PlannerStatusFlag == EnumMemPlannerStatusFlag.Passed);
                }
                else if (integralCount >= 5001)
                {
                    DMS.Create<Mem_MemberPlanner>().Edit(new Mem_MemberPlanner
                    {
                        PlannerLevel = 4,
                    }, q => q.MemberName == userID && q.PlannerStatusFlag == EnumMemPlannerStatusFlag.Passed);
                }
                else if (integralCount >= 2001)
                {
                    DMS.Create<Mem_MemberPlanner>().Edit(new Mem_MemberPlanner
                    {
                        PlannerLevel = 3,
                    }, q => q.MemberName == userID && q.PlannerStatusFlag == EnumMemPlannerStatusFlag.Passed);
                }
                else if (integralCount >= 501)
                {
                    DMS.Create<Mem_MemberPlanner>().Edit(new Mem_MemberPlanner
                    {
                        PlannerLevel = 2,
                    }, q => q.MemberName == userID && q.PlannerStatusFlag == EnumMemPlannerStatusFlag.Passed);
                }
                else if (integralCount > 0)
                {
                    DMS.Create<Mem_MemberPlanner>().Edit(new Mem_MemberPlanner
                    {
                        PlannerLevel = 1,
                    }, q => q.MemberName == userID && q.PlannerStatusFlag == EnumMemPlannerStatusFlag.Passed);
                }

            }
        }

        /// <summary>
        /// 今日总积分
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="socialID"></param>
        /// <returns></returns>
        public int TodayIntegral(string userID, List<int> socialID)
        {
            DateTime time = DateTime.Now.Date;
            int count = DMS.Create<Mem_MemberIntegral>().Where(p => p.MemberName == userID && p.CreateTime >= time && p.PayOutIn == 1 && p.IntegralSource.Value.In(socialID)).Sum(q => q.CurrentIntegral.Value);
            return count;
        }

        /// <summary>
        /// 用户总积分
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="socialID"></param>
        /// <returns></returns>
        public int IntegralCount(string userID)
        {
            return DMS.Create<Mem_MemberIntegral>().Where(p => p.MemberName == userID && p.PayOutIn == 1).Sum(q => q.CurrentIntegral.Value);

        }

        /// <summary>
        /// 截取省 市
        /// </summary>
        /// <param name="AreaPath"></param>
        /// <returns></returns>
        public string GetProvinceAndCity(string AreaPath)
        {
            string result = string.Empty;
            string[] arr = AreaPath.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length > 1)
            {
                if (arr[0] == arr[1])
                {
                    result = arr[0];
                }
                else
                {
                    result = arr[0] + " " + arr[1];
                }
            }
            return result;
        }

        /// <summary>
        /// 运营部发产品的理财师
        /// </summary>
        /// <returns></returns>
        public List<string> MobileList()
        {
            List<string> list = new List<string> {
                "13809968952"
                ,"13809961741"
                ,"13040594281"
                ,"13565178937"
                ,"13119068947"
                ,"13289067402"
                ,"13699946523"
                ,"15719018923"
                ,"15695358978"
                ,"13099342646"
                ,"13139418927"
                ,"13195808903"
                ,"13389398973"
                ,"13519098871"
                ,"13919578981"
                ,"13993968959"
                ,"15103968952"
            };
            return list;
        }
    }
}
