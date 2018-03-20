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

namespace CSTJR.RPC.Message.Contracts
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class JobResult : TBase
  {
    private int _successCount;
    private int _errCount;
    private string _errMsg;

    public int SuccessCount
    {
      get
      {
        return _successCount;
      }
      set
      {
        __isset.successCount = true;
        this._successCount = value;
      }
    }

    public int ErrCount
    {
      get
      {
        return _errCount;
      }
      set
      {
        __isset.errCount = true;
        this._errCount = value;
      }
    }

    public string ErrMsg
    {
      get
      {
        return _errMsg;
      }
      set
      {
        __isset.errMsg = true;
        this._errMsg = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool successCount;
      public bool errCount;
      public bool errMsg;
    }

    public JobResult() {
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
              if (field.Type == TType.I32) {
                SuccessCount = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.I32) {
                ErrCount = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.String) {
                ErrMsg = iprot.ReadString();
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
        TStruct struc = new TStruct("JobResult");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.successCount) {
          field.Name = "successCount";
          field.Type = TType.I32;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(SuccessCount);
          oprot.WriteFieldEnd();
        }
        if (__isset.errCount) {
          field.Name = "errCount";
          field.Type = TType.I32;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(ErrCount);
          oprot.WriteFieldEnd();
        }
        if (ErrMsg != null && __isset.errMsg) {
          field.Name = "errMsg";
          field.Type = TType.String;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(ErrMsg);
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
      StringBuilder __sb = new StringBuilder("JobResult(");
      bool __first = true;
      if (__isset.successCount) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("SuccessCount: ");
        __sb.Append(SuccessCount);
      }
      if (__isset.errCount) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ErrCount: ");
        __sb.Append(ErrCount);
      }
      if (ErrMsg != null && __isset.errMsg) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ErrMsg: ");
        __sb.Append(ErrMsg);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}