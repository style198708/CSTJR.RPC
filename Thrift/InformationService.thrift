namespace csharp CSTJR.RPC.Interface
service InformationService{
   list<FollowMember> GetMyFollowMember(1:string memberName)
   bool IsFollowing(1:string memberName, 2:string myID)
   list<string> GetAllFollowMember(1:string memberName)
   bool DeleteCollection(1:string memberName, 2:string userName, 3:i32 collectionID)
   i32 GetPostFabulousCount(1:string memberName)
   i32 GetColumnFabulousCount(1:string memberName)
   i32 GetCommentFabulousCount(1:string memberName)
   i32 GetFollowMeCount(1:string memberName)
   i32 GetFollowCount(1:string memberName)
   i32 GetFabulousCount(1:string memberName)
   list<CommentResult> GetCommentList(1:string memberName, 2:i32 RelationID, 3:i32 CommentType)
}

struct  FollowMember
{
   1:string  MemberName,
   2:string  Logo,
   3:string  NickName,
   4:string  Mobile,
   5:i32  IsFollow
}

struct CommentResult
{
   1:i32 CommentID ,

   2:i32 CommentType ,

   3:i32 RelationID ,

   4:string RelationName ,

   5:i32 ParentID ,

   6:string CommentContent ,

   7:string MemberName,

   8:i32 IsFabulous ,

   9:i32 IsDelete ,

   10:i32 FabulousCount ,

   11:string MemberLogo ,

   12:string NickName ,

   13:string CommentTime,

   14:string CreateTime ,

   15:list<CommentResult> CommentList ,
}