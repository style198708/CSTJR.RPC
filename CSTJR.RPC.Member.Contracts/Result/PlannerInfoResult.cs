/**
 * Autogenerated by Thrift Compiler (0.10.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace CSTJR.RPC.Member.Contracts
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class PlannerInfoResult : TBase
  {
    private string _MemberID;
    private string _Logo;
    private string _MemberName;
    private string _NickName;
    private string _TrueName;
    private string _SexType;
    private string _MemberType;
    private string _ShortIntroduction;
    private string _Area;
    private string _Mobile;
    private string _Email;
    private string _CompanyName;
    private string _Title;
    private string _IDNo;
    private string _WorkYears;
    private int _Level;
    private string _LevelName;
    private string _ApplyTime;
    private string _VerifyTime;
    private string _Status;
    private string _StatusRemark;
    private string _RegistTime;

    public string MemberID
    {
      get
      {
        return _MemberID;
      }
      set
      {
        __isset.MemberID = true;
        this._MemberID = value;
      }
    }

    public string Logo
    {
      get
      {
        return _Logo;
      }
      set
      {
        __isset.Logo = true;
        this._Logo = value;
      }
    }

    public string MemberName
    {
      get
      {
        return _MemberName;
      }
      set
      {
        __isset.MemberName = true;
        this._MemberName = value;
      }
    }

    public string NickName
    {
      get
      {
        return _NickName;
      }
      set
      {
        __isset.NickName = true;
        this._NickName = value;
      }
    }

    public string TrueName
    {
      get
      {
        return _TrueName;
      }
      set
      {
        __isset.TrueName = true;
        this._TrueName = value;
      }
    }

    public string SexType
    {
      get
      {
        return _SexType;
      }
      set
      {
        __isset.SexType = true;
        this._SexType = value;
      }
    }

    public string MemberType
    {
      get
      {
        return _MemberType;
      }
      set
      {
        __isset.MemberType = true;
        this._MemberType = value;
      }
    }

    public string ShortIntroduction
    {
      get
      {
        return _ShortIntroduction;
      }
      set
      {
        __isset.ShortIntroduction = true;
        this._ShortIntroduction = value;
      }
    }

    public string Area
    {
      get
      {
        return _Area;
      }
      set
      {
        __isset.Area = true;
        this._Area = value;
      }
    }

    public string Mobile
    {
      get
      {
        return _Mobile;
      }
      set
      {
        __isset.Mobile = true;
        this._Mobile = value;
      }
    }

    public string Email
    {
      get
      {
        return _Email;
      }
      set
      {
        __isset.Email = true;
        this._Email = value;
      }
    }

    public string CompanyName
    {
      get
      {
        return _CompanyName;
      }
      set
      {
        __isset.CompanyName = true;
        this._CompanyName = value;
      }
    }

    public string Title
    {
      get
      {
        return _Title;
      }
      set
      {
        __isset.Title = true;
        this._Title = value;
      }
    }

    public string IDNo
    {
      get
      {
        return _IDNo;
      }
      set
      {
        __isset.IDNo = true;
        this._IDNo = value;
      }
    }

    public string WorkYears
    {
      get
      {
        return _WorkYears;
      }
      set
      {
        __isset.WorkYears = true;
        this._WorkYears = value;
      }
    }

    public int Level
    {
      get
      {
        return _Level;
      }
      set
      {
        __isset.Level = true;
        this._Level = value;
      }
    }

    public string LevelName
    {
      get
      {
        return _LevelName;
      }
      set
      {
        __isset.LevelName = true;
        this._LevelName = value;
      }
    }

    public string ApplyTime
    {
      get
      {
        return _ApplyTime;
      }
      set
      {
        __isset.ApplyTime = true;
        this._ApplyTime = value;
      }
    }

    public string VerifyTime
    {
      get
      {
        return _VerifyTime;
      }
      set
      {
        __isset.VerifyTime = true;
        this._VerifyTime = value;
      }
    }

    public string Status
    {
      get
      {
        return _Status;
      }
      set
      {
        __isset.Status = true;
        this._Status = value;
      }
    }

    public string StatusRemark
    {
      get
      {
        return _StatusRemark;
      }
      set
      {
        __isset.StatusRemark = true;
        this._StatusRemark = value;
      }
    }

    public string RegistTime
    {
      get
      {
        return _RegistTime;
      }
      set
      {
        __isset.RegistTime = true;
        this._RegistTime = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool MemberID;
      public bool Logo;
      public bool MemberName;
      public bool NickName;
      public bool TrueName;
      public bool SexType;
      public bool MemberType;
      public bool ShortIntroduction;
      public bool Area;
      public bool Mobile;
      public bool Email;
      public bool CompanyName;
      public bool Title;
      public bool IDNo;
      public bool WorkYears;
      public bool Level;
      public bool LevelName;
      public bool ApplyTime;
      public bool VerifyTime;
      public bool Status;
      public bool StatusRemark;
      public bool RegistTime;
    }

    public PlannerInfoResult() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String) {
                MemberID = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                Logo = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.String) {
                MemberName = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.String) {
                NickName = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 5:
              if (field.Type == TType.String) {
                TrueName = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 6:
              if (field.Type == TType.String) {
                SexType = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 7:
              if (field.Type == TType.String) {
                MemberType = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 8:
              if (field.Type == TType.String) {
                ShortIntroduction = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 9:
              if (field.Type == TType.String) {
                Area = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 11:
              if (field.Type == TType.String) {
                Mobile = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 12:
              if (field.Type == TType.String) {
                Email = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 13:
              if (field.Type == TType.String) {
                CompanyName = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 14:
              if (field.Type == TType.String) {
                Title = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 15:
              if (field.Type == TType.String) {
                IDNo = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 16:
              if (field.Type == TType.String) {
                WorkYears = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 17:
              if (field.Type == TType.I32) {
                Level = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 18:
              if (field.Type == TType.String) {
                LevelName = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 19:
              if (field.Type == TType.String) {
                ApplyTime = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 20:
              if (field.Type == TType.String) {
                VerifyTime = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 21:
              if (field.Type == TType.String) {
                Status = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 22:
              if (field.Type == TType.String) {
                StatusRemark = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 23:
              if (field.Type == TType.String) {
                RegistTime = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("PlannerInfoResult");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (MemberID != null && __isset.MemberID) {
          field.Name = "MemberID";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(MemberID);
          oprot.WriteFieldEnd();
        }
        if (Logo != null && __isset.Logo) {
          field.Name = "Logo";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Logo);
          oprot.WriteFieldEnd();
        }
        if (MemberName != null && __isset.MemberName) {
          field.Name = "MemberName";
          field.Type = TType.String;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(MemberName);
          oprot.WriteFieldEnd();
        }
        if (NickName != null && __isset.NickName) {
          field.Name = "NickName";
          field.Type = TType.String;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(NickName);
          oprot.WriteFieldEnd();
        }
        if (TrueName != null && __isset.TrueName) {
          field.Name = "TrueName";
          field.Type = TType.String;
          field.ID = 5;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(TrueName);
          oprot.WriteFieldEnd();
        }
        if (SexType != null && __isset.SexType) {
          field.Name = "SexType";
          field.Type = TType.String;
          field.ID = 6;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(SexType);
          oprot.WriteFieldEnd();
        }
        if (MemberType != null && __isset.MemberType) {
          field.Name = "MemberType";
          field.Type = TType.String;
          field.ID = 7;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(MemberType);
          oprot.WriteFieldEnd();
        }
        if (ShortIntroduction != null && __isset.ShortIntroduction) {
          field.Name = "ShortIntroduction";
          field.Type = TType.String;
          field.ID = 8;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(ShortIntroduction);
          oprot.WriteFieldEnd();
        }
        if (Area != null && __isset.Area) {
          field.Name = "Area";
          field.Type = TType.String;
          field.ID = 9;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Area);
          oprot.WriteFieldEnd();
        }
        if (Mobile != null && __isset.Mobile) {
          field.Name = "Mobile";
          field.Type = TType.String;
          field.ID = 11;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Mobile);
          oprot.WriteFieldEnd();
        }
        if (Email != null && __isset.Email) {
          field.Name = "Email";
          field.Type = TType.String;
          field.ID = 12;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Email);
          oprot.WriteFieldEnd();
        }
        if (CompanyName != null && __isset.CompanyName) {
          field.Name = "CompanyName";
          field.Type = TType.String;
          field.ID = 13;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(CompanyName);
          oprot.WriteFieldEnd();
        }
        if (Title != null && __isset.Title) {
          field.Name = "Title";
          field.Type = TType.String;
          field.ID = 14;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Title);
          oprot.WriteFieldEnd();
        }
        if (IDNo != null && __isset.IDNo) {
          field.Name = "IDNo";
          field.Type = TType.String;
          field.ID = 15;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(IDNo);
          oprot.WriteFieldEnd();
        }
        if (WorkYears != null && __isset.WorkYears) {
          field.Name = "WorkYears";
          field.Type = TType.String;
          field.ID = 16;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(WorkYears);
          oprot.WriteFieldEnd();
        }
        if (__isset.Level) {
          field.Name = "Level";
          field.Type = TType.I32;
          field.ID = 17;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Level);
          oprot.WriteFieldEnd();
        }
        if (LevelName != null && __isset.LevelName) {
          field.Name = "LevelName";
          field.Type = TType.String;
          field.ID = 18;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(LevelName);
          oprot.WriteFieldEnd();
        }
        if (ApplyTime != null && __isset.ApplyTime) {
          field.Name = "ApplyTime";
          field.Type = TType.String;
          field.ID = 19;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(ApplyTime);
          oprot.WriteFieldEnd();
        }
        if (VerifyTime != null && __isset.VerifyTime) {
          field.Name = "VerifyTime";
          field.Type = TType.String;
          field.ID = 20;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(VerifyTime);
          oprot.WriteFieldEnd();
        }
        if (Status != null && __isset.Status) {
          field.Name = "Status";
          field.Type = TType.String;
          field.ID = 21;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Status);
          oprot.WriteFieldEnd();
        }
        if (StatusRemark != null && __isset.StatusRemark) {
          field.Name = "StatusRemark";
          field.Type = TType.String;
          field.ID = 22;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(StatusRemark);
          oprot.WriteFieldEnd();
        }
        if (RegistTime != null && __isset.RegistTime) {
          field.Name = "RegistTime";
          field.Type = TType.String;
          field.ID = 23;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(RegistTime);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("PlannerInfoResult(");
      bool __first = true;
      if (MemberID != null && __isset.MemberID) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("MemberID: ");
        __sb.Append(MemberID);
      }
      if (Logo != null && __isset.Logo) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Logo: ");
        __sb.Append(Logo);
      }
      if (MemberName != null && __isset.MemberName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("MemberName: ");
        __sb.Append(MemberName);
      }
      if (NickName != null && __isset.NickName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("NickName: ");
        __sb.Append(NickName);
      }
      if (TrueName != null && __isset.TrueName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("TrueName: ");
        __sb.Append(TrueName);
      }
      if (SexType != null && __isset.SexType) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("SexType: ");
        __sb.Append(SexType);
      }
      if (MemberType != null && __isset.MemberType) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("MemberType: ");
        __sb.Append(MemberType);
      }
      if (ShortIntroduction != null && __isset.ShortIntroduction) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ShortIntroduction: ");
        __sb.Append(ShortIntroduction);
      }
      if (Area != null && __isset.Area) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Area: ");
        __sb.Append(Area);
      }
      if (Mobile != null && __isset.Mobile) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Mobile: ");
        __sb.Append(Mobile);
      }
      if (Email != null && __isset.Email) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Email: ");
        __sb.Append(Email);
      }
      if (CompanyName != null && __isset.CompanyName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("CompanyName: ");
        __sb.Append(CompanyName);
      }
      if (Title != null && __isset.Title) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Title: ");
        __sb.Append(Title);
      }
      if (IDNo != null && __isset.IDNo) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("IDNo: ");
        __sb.Append(IDNo);
      }
      if (WorkYears != null && __isset.WorkYears) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("WorkYears: ");
        __sb.Append(WorkYears);
      }
      if (__isset.Level) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Level: ");
        __sb.Append(Level);
      }
      if (LevelName != null && __isset.LevelName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("LevelName: ");
        __sb.Append(LevelName);
      }
      if (ApplyTime != null && __isset.ApplyTime) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ApplyTime: ");
        __sb.Append(ApplyTime);
      }
      if (VerifyTime != null && __isset.VerifyTime) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("VerifyTime: ");
        __sb.Append(VerifyTime);
      }
      if (Status != null && __isset.Status) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Status: ");
        __sb.Append(Status);
      }
      if (StatusRemark != null && __isset.StatusRemark) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("StatusRemark: ");
        __sb.Append(StatusRemark);
      }
      if (RegistTime != null && __isset.RegistTime) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("RegistTime: ");
        __sb.Append(RegistTime);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
