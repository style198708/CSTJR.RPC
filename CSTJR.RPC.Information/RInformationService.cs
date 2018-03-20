using CSTJR.Enum;
using CSTJR.Member.Entity.DBEntity;
using CSTJR.Publish.Entity.DBEntity;
using CSTJR.Publish.Entity.ViewEntity;
using CSTJR.RPC.Information.Contracts;
using DMSFrame;
using System.Collections.Generic;
using System.Linq;
using TYSystem.BaseFramework.Common.Extension;
using TYSystem.BaseFramework.Common.Helper;

namespace CSTJR.RPC.Information
{
    public class RInformationService : InformationService.Iface
    {
        /// <summary>
        /// 我关注的人
        /// </summary>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public List<FollowMember> GetMyFollowMember(string memberName)
        {
            List<FollowMember> flist = new List<FollowMember>();
            string[] uids = DMS.Create<Follow>().Where(p => p.DeleteFlag == false && p.MemberName == memberName && p.FollowType == EnumFollowType.Planner).ToList().Select(p => p.RelationID).ToArray();
            if (uids.Length <= 0)
            {
                return flist;
            }
            List<Mem_MemberAccount> mlist = DMS.Create<Mem_MemberAccount>().Where(p => p.MemberName.In(uids)).ToList();
            if (mlist != null && mlist.Count > 0)
            {
                mlist.ForEach(p =>
                {
                    flist.Add(new FollowMember()
                    {
                        Logo = p.Logo,
                        MemberName = p.MemberName,
                        NickName = p.MemberName
                    });
                });
            }
            return flist;
        }

        /// <summary>
        /// 是否已关注此人
        /// </summary>
        /// <param name="memberName"></param>
        /// <param name="myID"></param>
        /// <returns></returns>
        public bool IsFollowing(string memberName, string myID)
        {
            Follow entity = DMS.Create<Follow>().Where(q => q.FollowType == EnumFollowType.Planner && q.RelationID == memberName && q.MemberName == myID && q.DeleteFlag == false).FirstOrDefault();
            if (entity != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 取所有粉丝
        /// </summary>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public List<string> GetAllFollowMember(string memberName)
        {
            List<Follow> flist = DMS.Create<Follow>()
                .Where(p => p.DeleteFlag == false && p.RelationID == memberName && p.FollowType == EnumFollowType.Planner && p.DeleteFlag == false)
                .ToList<Follow>();
            if (flist != null && flist.Count > 0)
            {
                return flist.Select(p => p.MemberName).ToList();
            }
            else
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="memberName"></param>
        /// <param name="userName"></param>
        /// <param name="postID"></param>
        /// <returns></returns>
        public bool DeleteCollection(string memberName, string userName, int collectionID)
        {
            Collection dataEntity = DMS.Create<Collection>().Where(q => q.CollectionID == collectionID && q.MemberName == memberName && q.DeleteFlag == false).ToEntity();
            if (dataEntity == null)
            {
                return false;
            }
            string errMsg = string.Empty;
            Collection updateEntity = new Collection()
            {
                DeleteFlag = true,
            };
            int result = DMS.Create<Collection>().Edit(updateEntity, q => q.CollectionID == collectionID && q.MemberName == memberName);
            return result > 0;
        }

        /// <summary>
        /// 动态 我获得的点赞数
        /// </summary>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public int GetPostFabulousCount(string memberName)
        {
            List<vw_PostMSTInfo> list = DMS.Create<vw_PostMSTInfo>()
                .Select(q => q.Columns(q.CurrentType, q.MemberName, q.FabulousCount, q.DeleteFlag))
                .Where(q => q.CurrentType == EnumFabulousType.DynamicType && q.MemberName == memberName && q.DeleteFlag == false)
                .ToList();
            int? count = list.Sum(p => p.FabulousCount);
            return count.ToInt(); ;
        }

        /// <summary>
        /// 专栏 我获得的点赞数
        /// </summary>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public int GetColumnFabulousCount(string memberName)
        {
            List<vw_PublishMSTInfo> list = DMS.Create<vw_PublishMSTInfo>()
                .Select(q => q.Columns(q.CurrentType, q.MemberName, q.FabulousCount, q.DeleteFlag))
                .Where(q => q.CurrentType == EnumFabulousType.Column && q.MemberName == memberName && q.DeleteFlag == false)
                .ToList();
            int? count = list.Sum(p => p.FabulousCount);
            return count.ToInt();
        }

        /// <summary>
        /// 评论 我获得的点赞数
        /// </summary>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public int GetCommentFabulousCount(string memberName)
        {
            int?[] commentIDs = DMS.Create<Comment>()
                .Where(q => q.MemberName == memberName && q.DeleteFlag == false).ToList()
                .Select(item => item.RelationID).ToArray();
            List<Fabulous> fabulousList = DMS.Create<Fabulous>()
                .Where(q => q.RelationID.In(commentIDs) && q.FabulousType == EnumFabulousType.Comment && q.IsEffect == 0 && q.DeleteFlag == false).ToList();
            return fabulousList.Count();

        }

        /// <summary>
        /// 取我的粉丝数
        /// </summary>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public int GetFollowMeCount(string memberName)
        {
            List<Follow> list = DMS.Create<Follow>().Where(p => p.DeleteFlag == false && p.RelationID == memberName && p.FollowType == EnumFollowType.Planner).ToList();
            int count = list.Select(p => p.MemberName).Distinct().Count();
            return count;
        }

        /// <summary>
        /// 取我的关注数
        /// </summary>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public int GetFollowCount(string memberName)
        {
            List<Follow> list = DMS.Create<Follow>().Where(p => p.MemberName == memberName && p.RelationID != memberName && p.FollowType == EnumFollowType.Planner && p.DeleteFlag == false).ToList();
            if (memberName.In(EnumOfficialUser.JXTT, EnumOfficialUser.LMS, EnumOfficialUser.GFKF, EnumOfficialUser.DWGS, EnumOfficialUser.YXJJ))
            {
                return 0;
            }
            int count = list.Select(p => p.RelationID).Distinct().Count();
            return count;
        }

        /// <summary>
        /// 获取点赞总数
        /// </summary>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public int GetFabulousCount(string memberName)
        {
            ///专栏的点赞总数
            int pcount = DMS.Create<vw_PublishMSTInfo>()
                  .Where(p => p.DeleteFlag == false && p.MemberName == memberName && p.CurrentType == EnumPublishType.Column)
                  .Sum(p => p.FabulousCount).ToInt();

            ///动态，吐槽
            int postcount = DMS.Create<vw_PostMSTInfo>()
                  .Where(p => p.DeleteFlag == false && p.MemberName == memberName)
                  .Sum(p => p.FabulousCount).ToInt();

            ///评论
            int commentcount = DMS.Create<Comment>()
               .Where(p => p.DeleteFlag == false && p.MemberName == memberName)
               .Sum(p => p.FabulousCount).ToInt();

            return pcount + postcount + commentcount;
        }

        /// <summary>
        /// 评论集合
        /// </summary>
        /// <param name="RelationID"></param>
        /// <param name="CommentType"></param>
        /// <returns></returns>
        public List<CommentResult> GetCommentList(string memberName, int RelationID, int CommentType)
        {
            List<CommentResult> list = new List<CommentResult>();
            //个人信息不作冗余是因为图像会经常改动
            List<Comment> flist = DMS.Create<Comment>().Where(p => p.DeleteFlag == false && p.FirstParentID == RelationID && p.FirstParentType == CommentType).ToList();
            ///所有评论的人
            string[] uids = flist.Select(p => p.MemberName).ToArray();
            ///所有评论集合
            int?[] cids = flist.Select(p => p.CommentID).ToArray();
            ///所有评论的点赞集合
            List<Fabulous> fabulouss = DMS.Create<Fabulous>().Where(p => p.RelationID.In(cids) && p.FabulousType == EnumFabulousType.Comment && p.IsEffect == 1).ToList();
            List<Mem_MemberAccount> ulist = DMS.Create<Mem_MemberAccount>().Where(p => p.MemberName.In(uids)).ToList();

            ulist.ForEach(m =>
            {
                m.Logo = FileHelper.GetThumbnailPath(m.Logo, EnumSysImageDir.MEMBERLOGO);
            });
            CommentList(flist, ulist, fabulouss, memberName, 0, ref list);
            list = list.OrderByDescending(p => p.FabulousCount).ToList();
            return list;
        }

        /// <summary>
        /// 递归获取评论
        /// </summary>
        public void CommentList(List<Comment> flist, List<Mem_MemberAccount> ulist, List<Fabulous> fabulouss, string memberName, int? parentID, ref List<CommentResult> list)
        {
            foreach (Comment c in flist.Where(p => p.ParentID == parentID).ToList())
            {
                CommentResult re = new CommentResult()
                {
                    CommentID = c.CommentID.ToInt(),
                    CommentContent = c.CommentContent,
                    CommentType = c.CommentType.ToInt(),
                    ParentID = c.ParentID.ToInt(),
                    RelationID = c.RelationID.ToInt(),
                    RelationName = c.RelationName,
                    FabulousCount = c.FabulousCount.ToInt(),
                    CreateTime = c.CreateTime.ToString(),
                    IsDelete = memberName == c.MemberName ? 1 : 0,
                    CommentTime = c.CreateTime.Value.DateStringFromNow2()

                };
                Mem_MemberAccount memeber = ulist.Where(p => p.MemberName == c.MemberName).FirstOrDefault();
                if (memeber != null)
                {
                    re.NickName = memeber.NickName.ToStringDefault();
                    re.MemberName = memeber.MemberName;
                    re.MemberLogo = memeber.Logo;
                }
                else
                {
                    re.NickName = "未知";

                }
                Fabulous isfabulous = fabulouss.Where(p => p.RelationID == c.CommentID && p.MemberName == memberName).FirstOrDefault();
                re.IsFabulous = isfabulous == null ? 0 : 1;
                List<CommentResult> cl = new List<CommentResult>();
                List<Comment> clist = flist.Where(p => p.ParentID == c.CommentID).ToList();
                if (clist.Count() > 0)
                {
                    CommentList(flist, ulist, fabulouss, memberName, re.CommentID, ref cl);
                }
                re.CommentList = cl;
                list.Add(re);
            }
        }

    }
}
