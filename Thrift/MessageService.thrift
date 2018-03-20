namespace csharp CSTJR.RPC.Interface
service MessageService{
   bool SendMessage(1:JpushMessageParam model)
   JobResult SendTaskMessage()
}
struct  JpushMessageParam
{
   1:i32 Category,
   2:string  FromUser,
   3:string ToUser,
   4:list<string> ActionList,
   5:list<string> MessageList
}

struct JobResult
{
	1:i32 successCount,
	2:i32 errCount,
	3:string errMsg
}

