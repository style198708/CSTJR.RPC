namespace csharp CSTJR.RPC.Interface
service ProductService{
   list<ProductListResult> GetProductList(1:SearchProductParam param)
   list<ProductFundCompanyResult> GetProductFundCompanyList(1:list<i32> fundIDs)
}

struct ProductListResult
{
	1:i32 ProductID ,	
	2:string ProductName ,	
	3: i32 ProductType,	
	4: string CategoryName ,	
	5: string CodeName ,	
	6: string ProductStatusType,	
	7: string FundLogo,	
	8: string CompanyName ,	
	9: string MemberName ,	
	10: string CreateTime ,
	11: string ExtStr01,
	12: string ExtVaule01,
	13: string ExtStr02,
	14: string ExtVaule02,
	15: string ExtStr03,
	16: string ExtVaule03,
	17: string ExtStr04,
	18: string ExtVaule04

}

struct SearchProductParam
{
    1:list<i32> productIDs,
    2:string MemberName,
    3:list<string> MemberNames ,
    4:bool IsLogin
}

struct ProductFundCompanyResult
{
    1:i32 FundID,
    2:string FundLogo,
    3:string FundName,
    4:string FundDesc
}


