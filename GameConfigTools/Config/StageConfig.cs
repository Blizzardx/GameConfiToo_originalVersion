/**
 * Autogenerated by Thrift Compiler (0.9.1)
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

namespace Config
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class StageConfig : TBase
  {
    private int _id;
    private int _nextStageId;
    private int _chapterId;
    private string _titleResource;
    private int _nameMessageId;
    private int _descMessageId;
    private int _stageType;
    private int _unlockLimitId;
    private int _showMonsterId;
    private int _failLimitId;
    private int _totalTime;
    private int _winLimitId;
    private int _targetLimitId1;
    private int _targetFunc1;
    private int _targetMessageId1;
    private int _targetLimitId2;
    private int _targetFunc2;
    private int _targetMessageId2;
    private int _targetLimitId3;
    private int _targetFunc3;
    private int _targetMessageId3;
    private string _stageMaprResource;
    private int _starBit4CountId;
    private int _weatherPlanId;
    private int _beforeStoryId;
    private int _afterStoryId;
    private string _modelID;
    private string _modelAction;
    private string _modelActionPass;

    public int Id
    {
      get
      {
        return _id;
      }
      set
      {
        __isset.id = true;
        this._id = value;
      }
    }

    public int NextStageId
    {
      get
      {
        return _nextStageId;
      }
      set
      {
        __isset.nextStageId = true;
        this._nextStageId = value;
      }
    }

    public int ChapterId
    {
      get
      {
        return _chapterId;
      }
      set
      {
        __isset.chapterId = true;
        this._chapterId = value;
      }
    }

    public string TitleResource
    {
      get
      {
        return _titleResource;
      }
      set
      {
        __isset.titleResource = true;
        this._titleResource = value;
      }
    }

    public int NameMessageId
    {
      get
      {
        return _nameMessageId;
      }
      set
      {
        __isset.nameMessageId = true;
        this._nameMessageId = value;
      }
    }

    public int DescMessageId
    {
      get
      {
        return _descMessageId;
      }
      set
      {
        __isset.descMessageId = true;
        this._descMessageId = value;
      }
    }

    public int StageType
    {
      get
      {
        return _stageType;
      }
      set
      {
        __isset.stageType = true;
        this._stageType = value;
      }
    }

    public int UnlockLimitId
    {
      get
      {
        return _unlockLimitId;
      }
      set
      {
        __isset.unlockLimitId = true;
        this._unlockLimitId = value;
      }
    }

    public int ShowMonsterId
    {
      get
      {
        return _showMonsterId;
      }
      set
      {
        __isset.showMonsterId = true;
        this._showMonsterId = value;
      }
    }

    public int FailLimitId
    {
      get
      {
        return _failLimitId;
      }
      set
      {
        __isset.failLimitId = true;
        this._failLimitId = value;
      }
    }

    public int TotalTime
    {
      get
      {
        return _totalTime;
      }
      set
      {
        __isset.totalTime = true;
        this._totalTime = value;
      }
    }

    public int WinLimitId
    {
      get
      {
        return _winLimitId;
      }
      set
      {
        __isset.winLimitId = true;
        this._winLimitId = value;
      }
    }

    public int TargetLimitId1
    {
      get
      {
        return _targetLimitId1;
      }
      set
      {
        __isset.targetLimitId1 = true;
        this._targetLimitId1 = value;
      }
    }

    public int TargetFunc1
    {
      get
      {
        return _targetFunc1;
      }
      set
      {
        __isset.targetFunc1 = true;
        this._targetFunc1 = value;
      }
    }

    public int TargetMessageId1
    {
      get
      {
        return _targetMessageId1;
      }
      set
      {
        __isset.targetMessageId1 = true;
        this._targetMessageId1 = value;
      }
    }

    public int TargetLimitId2
    {
      get
      {
        return _targetLimitId2;
      }
      set
      {
        __isset.targetLimitId2 = true;
        this._targetLimitId2 = value;
      }
    }

    public int TargetFunc2
    {
      get
      {
        return _targetFunc2;
      }
      set
      {
        __isset.targetFunc2 = true;
        this._targetFunc2 = value;
      }
    }

    public int TargetMessageId2
    {
      get
      {
        return _targetMessageId2;
      }
      set
      {
        __isset.targetMessageId2 = true;
        this._targetMessageId2 = value;
      }
    }

    public int TargetLimitId3
    {
      get
      {
        return _targetLimitId3;
      }
      set
      {
        __isset.targetLimitId3 = true;
        this._targetLimitId3 = value;
      }
    }

    public int TargetFunc3
    {
      get
      {
        return _targetFunc3;
      }
      set
      {
        __isset.targetFunc3 = true;
        this._targetFunc3 = value;
      }
    }

    public int TargetMessageId3
    {
      get
      {
        return _targetMessageId3;
      }
      set
      {
        __isset.targetMessageId3 = true;
        this._targetMessageId3 = value;
      }
    }

    public string StageMaprResource
    {
      get
      {
        return _stageMaprResource;
      }
      set
      {
        __isset.stageMaprResource = true;
        this._stageMaprResource = value;
      }
    }

    public int StarBit4CountId
    {
      get
      {
        return _starBit4CountId;
      }
      set
      {
        __isset.starBit4CountId = true;
        this._starBit4CountId = value;
      }
    }

    public int WeatherPlanId
    {
      get
      {
        return _weatherPlanId;
      }
      set
      {
        __isset.weatherPlanId = true;
        this._weatherPlanId = value;
      }
    }

    public int BeforeStoryId
    {
      get
      {
        return _beforeStoryId;
      }
      set
      {
        __isset.beforeStoryId = true;
        this._beforeStoryId = value;
      }
    }

    public int AfterStoryId
    {
      get
      {
        return _afterStoryId;
      }
      set
      {
        __isset.afterStoryId = true;
        this._afterStoryId = value;
      }
    }

    public string ModelID
    {
      get
      {
        return _modelID;
      }
      set
      {
        __isset.modelID = true;
        this._modelID = value;
      }
    }

    public string ModelAction
    {
      get
      {
        return _modelAction;
      }
      set
      {
        __isset.modelAction = true;
        this._modelAction = value;
      }
    }

    public string ModelActionPass
    {
      get
      {
        return _modelActionPass;
      }
      set
      {
        __isset.modelActionPass = true;
        this._modelActionPass = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool nextStageId;
      public bool chapterId;
      public bool titleResource;
      public bool nameMessageId;
      public bool descMessageId;
      public bool stageType;
      public bool unlockLimitId;
      public bool showMonsterId;
      public bool failLimitId;
      public bool totalTime;
      public bool winLimitId;
      public bool targetLimitId1;
      public bool targetFunc1;
      public bool targetMessageId1;
      public bool targetLimitId2;
      public bool targetFunc2;
      public bool targetMessageId2;
      public bool targetLimitId3;
      public bool targetFunc3;
      public bool targetMessageId3;
      public bool stageMaprResource;
      public bool starBit4CountId;
      public bool weatherPlanId;
      public bool beforeStoryId;
      public bool afterStoryId;
      public bool modelID;
      public bool modelAction;
      public bool modelActionPass;
    }

    public StageConfig() {
    }

    public void Read (TProtocol iprot)
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
          case 10:
            if (field.Type == TType.I32) {
              Id = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 11:
            if (field.Type == TType.I32) {
              NextStageId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 12:
            if (field.Type == TType.I32) {
              ChapterId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 13:
            if (field.Type == TType.String) {
              TitleResource = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.I32) {
              NameMessageId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.I32) {
              DescMessageId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 31:
            if (field.Type == TType.I32) {
              StageType = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 32:
            if (field.Type == TType.I32) {
              UnlockLimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 33:
            if (field.Type == TType.I32) {
              ShowMonsterId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 34:
            if (field.Type == TType.I32) {
              FailLimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 35:
            if (field.Type == TType.I32) {
              TotalTime = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 130:
            if (field.Type == TType.I32) {
              WinLimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 140:
            if (field.Type == TType.I32) {
              TargetLimitId1 = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 141:
            if (field.Type == TType.I32) {
              TargetFunc1 = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 142:
            if (field.Type == TType.I32) {
              TargetMessageId1 = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 143:
            if (field.Type == TType.I32) {
              TargetLimitId2 = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 144:
            if (field.Type == TType.I32) {
              TargetFunc2 = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 145:
            if (field.Type == TType.I32) {
              TargetMessageId2 = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 146:
            if (field.Type == TType.I32) {
              TargetLimitId3 = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 147:
            if (field.Type == TType.I32) {
              TargetFunc3 = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 148:
            if (field.Type == TType.I32) {
              TargetMessageId3 = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 149:
            if (field.Type == TType.String) {
              StageMaprResource = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 180:
            if (field.Type == TType.I32) {
              StarBit4CountId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 190:
            if (field.Type == TType.I32) {
              WeatherPlanId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 200:
            if (field.Type == TType.I32) {
              BeforeStoryId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 210:
            if (field.Type == TType.I32) {
              AfterStoryId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 220:
            if (field.Type == TType.String) {
              ModelID = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 230:
            if (field.Type == TType.String) {
              ModelAction = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 240:
            if (field.Type == TType.String) {
              ModelActionPass = iprot.ReadString();
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

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("StageConfig");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.id) {
        field.Name = "id";
        field.Type = TType.I32;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Id);
        oprot.WriteFieldEnd();
      }
      if (__isset.nextStageId) {
        field.Name = "nextStageId";
        field.Type = TType.I32;
        field.ID = 11;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(NextStageId);
        oprot.WriteFieldEnd();
      }
      if (__isset.chapterId) {
        field.Name = "chapterId";
        field.Type = TType.I32;
        field.ID = 12;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ChapterId);
        oprot.WriteFieldEnd();
      }
      if (TitleResource != null && __isset.titleResource) {
        field.Name = "titleResource";
        field.Type = TType.String;
        field.ID = 13;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(TitleResource);
        oprot.WriteFieldEnd();
      }
      if (__isset.nameMessageId) {
        field.Name = "nameMessageId";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(NameMessageId);
        oprot.WriteFieldEnd();
      }
      if (__isset.descMessageId) {
        field.Name = "descMessageId";
        field.Type = TType.I32;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DescMessageId);
        oprot.WriteFieldEnd();
      }
      if (__isset.stageType) {
        field.Name = "stageType";
        field.Type = TType.I32;
        field.ID = 31;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(StageType);
        oprot.WriteFieldEnd();
      }
      if (__isset.unlockLimitId) {
        field.Name = "unlockLimitId";
        field.Type = TType.I32;
        field.ID = 32;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(UnlockLimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.showMonsterId) {
        field.Name = "showMonsterId";
        field.Type = TType.I32;
        field.ID = 33;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ShowMonsterId);
        oprot.WriteFieldEnd();
      }
      if (__isset.failLimitId) {
        field.Name = "failLimitId";
        field.Type = TType.I32;
        field.ID = 34;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(FailLimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.totalTime) {
        field.Name = "totalTime";
        field.Type = TType.I32;
        field.ID = 35;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TotalTime);
        oprot.WriteFieldEnd();
      }
      if (__isset.winLimitId) {
        field.Name = "winLimitId";
        field.Type = TType.I32;
        field.ID = 130;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(WinLimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.targetLimitId1) {
        field.Name = "targetLimitId1";
        field.Type = TType.I32;
        field.ID = 140;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TargetLimitId1);
        oprot.WriteFieldEnd();
      }
      if (__isset.targetFunc1) {
        field.Name = "targetFunc1";
        field.Type = TType.I32;
        field.ID = 141;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TargetFunc1);
        oprot.WriteFieldEnd();
      }
      if (__isset.targetMessageId1) {
        field.Name = "targetMessageId1";
        field.Type = TType.I32;
        field.ID = 142;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TargetMessageId1);
        oprot.WriteFieldEnd();
      }
      if (__isset.targetLimitId2) {
        field.Name = "targetLimitId2";
        field.Type = TType.I32;
        field.ID = 143;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TargetLimitId2);
        oprot.WriteFieldEnd();
      }
      if (__isset.targetFunc2) {
        field.Name = "targetFunc2";
        field.Type = TType.I32;
        field.ID = 144;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TargetFunc2);
        oprot.WriteFieldEnd();
      }
      if (__isset.targetMessageId2) {
        field.Name = "targetMessageId2";
        field.Type = TType.I32;
        field.ID = 145;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TargetMessageId2);
        oprot.WriteFieldEnd();
      }
      if (__isset.targetLimitId3) {
        field.Name = "targetLimitId3";
        field.Type = TType.I32;
        field.ID = 146;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TargetLimitId3);
        oprot.WriteFieldEnd();
      }
      if (__isset.targetFunc3) {
        field.Name = "targetFunc3";
        field.Type = TType.I32;
        field.ID = 147;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TargetFunc3);
        oprot.WriteFieldEnd();
      }
      if (__isset.targetMessageId3) {
        field.Name = "targetMessageId3";
        field.Type = TType.I32;
        field.ID = 148;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TargetMessageId3);
        oprot.WriteFieldEnd();
      }
      if (StageMaprResource != null && __isset.stageMaprResource) {
        field.Name = "stageMaprResource";
        field.Type = TType.String;
        field.ID = 149;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(StageMaprResource);
        oprot.WriteFieldEnd();
      }
      if (__isset.starBit4CountId) {
        field.Name = "starBit4CountId";
        field.Type = TType.I32;
        field.ID = 180;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(StarBit4CountId);
        oprot.WriteFieldEnd();
      }
      if (__isset.weatherPlanId) {
        field.Name = "weatherPlanId";
        field.Type = TType.I32;
        field.ID = 190;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(WeatherPlanId);
        oprot.WriteFieldEnd();
      }
      if (__isset.beforeStoryId) {
        field.Name = "beforeStoryId";
        field.Type = TType.I32;
        field.ID = 200;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(BeforeStoryId);
        oprot.WriteFieldEnd();
      }
      if (__isset.afterStoryId) {
        field.Name = "afterStoryId";
        field.Type = TType.I32;
        field.ID = 210;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(AfterStoryId);
        oprot.WriteFieldEnd();
      }
      if (ModelID != null && __isset.modelID) {
        field.Name = "modelID";
        field.Type = TType.String;
        field.ID = 220;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(ModelID);
        oprot.WriteFieldEnd();
      }
      if (ModelAction != null && __isset.modelAction) {
        field.Name = "modelAction";
        field.Type = TType.String;
        field.ID = 230;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(ModelAction);
        oprot.WriteFieldEnd();
      }
      if (ModelActionPass != null && __isset.modelActionPass) {
        field.Name = "modelActionPass";
        field.Type = TType.String;
        field.ID = 240;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(ModelActionPass);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("StageConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",NextStageId: ");
      sb.Append(NextStageId);
      sb.Append(",ChapterId: ");
      sb.Append(ChapterId);
      sb.Append(",TitleResource: ");
      sb.Append(TitleResource);
      sb.Append(",NameMessageId: ");
      sb.Append(NameMessageId);
      sb.Append(",DescMessageId: ");
      sb.Append(DescMessageId);
      sb.Append(",StageType: ");
      sb.Append(StageType);
      sb.Append(",UnlockLimitId: ");
      sb.Append(UnlockLimitId);
      sb.Append(",ShowMonsterId: ");
      sb.Append(ShowMonsterId);
      sb.Append(",FailLimitId: ");
      sb.Append(FailLimitId);
      sb.Append(",TotalTime: ");
      sb.Append(TotalTime);
      sb.Append(",WinLimitId: ");
      sb.Append(WinLimitId);
      sb.Append(",TargetLimitId1: ");
      sb.Append(TargetLimitId1);
      sb.Append(",TargetFunc1: ");
      sb.Append(TargetFunc1);
      sb.Append(",TargetMessageId1: ");
      sb.Append(TargetMessageId1);
      sb.Append(",TargetLimitId2: ");
      sb.Append(TargetLimitId2);
      sb.Append(",TargetFunc2: ");
      sb.Append(TargetFunc2);
      sb.Append(",TargetMessageId2: ");
      sb.Append(TargetMessageId2);
      sb.Append(",TargetLimitId3: ");
      sb.Append(TargetLimitId3);
      sb.Append(",TargetFunc3: ");
      sb.Append(TargetFunc3);
      sb.Append(",TargetMessageId3: ");
      sb.Append(TargetMessageId3);
      sb.Append(",StageMaprResource: ");
      sb.Append(StageMaprResource);
      sb.Append(",StarBit4CountId: ");
      sb.Append(StarBit4CountId);
      sb.Append(",WeatherPlanId: ");
      sb.Append(WeatherPlanId);
      sb.Append(",BeforeStoryId: ");
      sb.Append(BeforeStoryId);
      sb.Append(",AfterStoryId: ");
      sb.Append(AfterStoryId);
      sb.Append(",ModelID: ");
      sb.Append(ModelID);
      sb.Append(",ModelAction: ");
      sb.Append(ModelAction);
      sb.Append(",ModelActionPass: ");
      sb.Append(ModelActionPass);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
