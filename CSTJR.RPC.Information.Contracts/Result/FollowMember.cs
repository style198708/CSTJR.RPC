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

namespace CSTJR.RPC.Information.Contracts
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class FollowMember : TBase
  {
    private string _MemberName;
    private string _Logo;
    private string _NickName;
    private string _Mobile;
    private int _IsFollow;

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

    public int IsFollow
    {
      get
      {
        return _IsFollow;
      }
      set
      {
        __isset.IsFollow = true;
        this._IsFollow = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool MemberName;
      public bool Logo;
      public bool NickName;
      public bool Mobile;
      public bool IsFollow;
    }

    public FollowMember() {
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
                MemberName = iprot.ReadString();
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
                NickName = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.String) {
                Mobile = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 5:
              if (field.Type == TType.I32) {
                IsFollow = iprot.ReadI32();
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
        TStruct struc = new TStruct("FollowMember");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (MemberName != null && __isset.MemberName) {
          field.Name = "MemberName";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(MemberName);
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
        if (NickName != null && __isset.NickName) {
          field.Name = "NickName";
          field.Type = TType.String;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(NickName);
          oprot.WriteFieldEnd();
        }
        if (Mobile != null && __isset.Mobile) {
          field.Name = "Mobile";
          field.Type = TType.String;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Mobile);
          oprot.WriteFieldEnd();
        }
        if (__isset.IsFollow) {
          field.Name = "IsFollow";
          field.Type = TType.I32;
          field.ID = 5;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(IsFollow);
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
      StringBuilder __sb = new StringBuilder("FollowMember(");
      bool __first = true;
      if (MemberName != null && __isset.MemberName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("MemberName: ");
        __sb.Append(MemberName);
      }
      if (Logo != null && __isset.Logo) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Logo: ");
        __sb.Append(Logo);
      }
      if (NickName != null && __isset.NickName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("NickName: ");
        __sb.Append(NickName);
      }
      if (Mobile != null && __isset.Mobile) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Mobile: ");
        __sb.Append(Mobile);
      }
      if (__isset.IsFollow) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("IsFollow: ");
        __sb.Append(IsFollow);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
