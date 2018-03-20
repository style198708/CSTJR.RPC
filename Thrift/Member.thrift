namespace csharp CSTJR.RPC.Interface

service MemberService{
   UserInfoResult GetUserInfo(1:string userID)
   PlannerInfoResult GetPlannerInfo(1:string userID)
   list<UserInfoResult> GetUserInfoBatch(1:list<string> userIDs)
   list<PlannerInfoResult> GetPlannerInfoBatch(1:list<string> userIDs)
   list<MemberImpressResult> GetMemberImpressList(1:string userID)
   void UpdateMemberIntegral(1:string userID, 2:string userName, 3:i32 IntegralSource, 4:i32 payOutIn)
   i32 TodayIntegral(1:string userID, 2:list<i32> socialID)
   i32 IntegralCount(1:string userID)
   string GetProvinceAndCity(1:string AreaPath)
   list<string> MobileList()
}
struct  UserInfoResult
{
     1:string MemberID,
	 2:string Logo,
     3:string MemberName,
	 4:string NickName,
	 5:string TrueName,
	 6:string SexType,
	 7:string MemberType,
	 8:string ShortIntroduction,
	 9:string Area,
	 10:string Mobile,
	 11:string Email,
     12:bool IsCognizance,
}

struct PlannerInfoResult
{
    1:string MemberID,
    2:string Logo,
    3:string MemberName,
	4:string NickName,
	5:string TrueName,
	6:string SexType,
	7:string MemberType,
	8:string ShortIntroduction,
	9:string Area,
	11:string Mobile,
	12:string Email,
    13:string CompanyName,
	14:string Title,
	15:string IDNo,
	16:string WorkYears,
    17:i32 Level,
    18:string LevelName,
    19:string ApplyTime,
	20:string VerifyTime,
	21:string Status,
	22:string StatusRemark,
    23:string RegistTime,
}

struct MemberImpressResult
{
    1:string ImpressContent,
    2:i32 Count
}

