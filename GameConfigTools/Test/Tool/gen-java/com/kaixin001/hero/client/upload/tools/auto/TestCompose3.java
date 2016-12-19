/**
 * Autogenerated by Thrift Compiler (0.9.1)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
package com.kaixin001.hero.client.upload.tools.auto;

import org.apache.thrift.scheme.IScheme;
import org.apache.thrift.scheme.SchemeFactory;
import org.apache.thrift.scheme.StandardScheme;

import org.apache.thrift.scheme.TupleScheme;
import org.apache.thrift.protocol.TTupleProtocol;
import org.apache.thrift.protocol.TProtocolException;
import org.apache.thrift.EncodingUtils;
import org.apache.thrift.TException;
import org.apache.thrift.async.AsyncMethodCallback;
import org.apache.thrift.server.AbstractNonblockingServer.*;
import java.util.List;
import java.util.ArrayList;
import java.util.Map;
import java.util.HashMap;
import java.util.EnumMap;
import java.util.Set;
import java.util.HashSet;
import java.util.EnumSet;
import java.util.Collections;
import java.util.BitSet;
import java.nio.ByteBuffer;
import java.util.Arrays;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class TestCompose3 implements org.apache.thrift.TBase<TestCompose3, TestCompose3._Fields>, java.io.Serializable, Cloneable, Comparable<TestCompose3> {
  private static final org.apache.thrift.protocol.TStruct STRUCT_DESC = new org.apache.thrift.protocol.TStruct("TestCompose3");

  private static final org.apache.thrift.protocol.TField TMP_LIST_FIELD_DESC = new org.apache.thrift.protocol.TField("tmpList", org.apache.thrift.protocol.TType.LIST, (short)1);

  private static final Map<Class<? extends IScheme>, SchemeFactory> schemes = new HashMap<Class<? extends IScheme>, SchemeFactory>();
  static {
    schemes.put(StandardScheme.class, new TestCompose3StandardSchemeFactory());
    schemes.put(TupleScheme.class, new TestCompose3TupleSchemeFactory());
  }

  public List<TestCompose1> tmpList; // required

  /** The set of fields this struct contains, along with convenience methods for finding and manipulating them. */
  public enum _Fields implements org.apache.thrift.TFieldIdEnum {
    TMP_LIST((short)1, "tmpList");

    private static final Map<String, _Fields> byName = new HashMap<String, _Fields>();

    static {
      for (_Fields field : EnumSet.allOf(_Fields.class)) {
        byName.put(field.getFieldName(), field);
      }
    }

    /**
     * Find the _Fields constant that matches fieldId, or null if its not found.
     */
    public static _Fields findByThriftId(int fieldId) {
      switch(fieldId) {
        case 1: // TMP_LIST
          return TMP_LIST;
        default:
          return null;
      }
    }

    /**
     * Find the _Fields constant that matches fieldId, throwing an exception
     * if it is not found.
     */
    public static _Fields findByThriftIdOrThrow(int fieldId) {
      _Fields fields = findByThriftId(fieldId);
      if (fields == null) throw new IllegalArgumentException("Field " + fieldId + " doesn't exist!");
      return fields;
    }

    /**
     * Find the _Fields constant that matches name, or null if its not found.
     */
    public static _Fields findByName(String name) {
      return byName.get(name);
    }

    private final short _thriftId;
    private final String _fieldName;

    _Fields(short thriftId, String fieldName) {
      _thriftId = thriftId;
      _fieldName = fieldName;
    }

    public short getThriftFieldId() {
      return _thriftId;
    }

    public String getFieldName() {
      return _fieldName;
    }
  }

  // isset id assignments
  public static final Map<_Fields, org.apache.thrift.meta_data.FieldMetaData> metaDataMap;
  static {
    Map<_Fields, org.apache.thrift.meta_data.FieldMetaData> tmpMap = new EnumMap<_Fields, org.apache.thrift.meta_data.FieldMetaData>(_Fields.class);
    tmpMap.put(_Fields.TMP_LIST, new org.apache.thrift.meta_data.FieldMetaData("tmpList", org.apache.thrift.TFieldRequirementType.DEFAULT, 
        new org.apache.thrift.meta_data.ListMetaData(org.apache.thrift.protocol.TType.LIST, 
            new org.apache.thrift.meta_data.StructMetaData(org.apache.thrift.protocol.TType.STRUCT, TestCompose1.class))));
    metaDataMap = Collections.unmodifiableMap(tmpMap);
    org.apache.thrift.meta_data.FieldMetaData.addStructMetaDataMap(TestCompose3.class, metaDataMap);
  }

  public TestCompose3() {
  }

  public TestCompose3(
    List<TestCompose1> tmpList)
  {
    this();
    this.tmpList = tmpList;
  }

  /**
   * Performs a deep copy on <i>other</i>.
   */
  public TestCompose3(TestCompose3 other) {
    if (other.isSetTmpList()) {
      List<TestCompose1> __this__tmpList = new ArrayList<TestCompose1>(other.tmpList.size());
      for (TestCompose1 other_element : other.tmpList) {
        __this__tmpList.add(new TestCompose1(other_element));
      }
      this.tmpList = __this__tmpList;
    }
  }

  public TestCompose3 deepCopy() {
    return new TestCompose3(this);
  }

  @Override
  public void clear() {
    this.tmpList = null;
  }

  public int getTmpListSize() {
    return (this.tmpList == null) ? 0 : this.tmpList.size();
  }

  public java.util.Iterator<TestCompose1> getTmpListIterator() {
    return (this.tmpList == null) ? null : this.tmpList.iterator();
  }

  public void addToTmpList(TestCompose1 elem) {
    if (this.tmpList == null) {
      this.tmpList = new ArrayList<TestCompose1>();
    }
    this.tmpList.add(elem);
  }

  public List<TestCompose1> getTmpList() {
    return this.tmpList;
  }

  public TestCompose3 setTmpList(List<TestCompose1> tmpList) {
    this.tmpList = tmpList;
    return this;
  }

  public void unsetTmpList() {
    this.tmpList = null;
  }

  /** Returns true if field tmpList is set (has been assigned a value) and false otherwise */
  public boolean isSetTmpList() {
    return this.tmpList != null;
  }

  public void setTmpListIsSet(boolean value) {
    if (!value) {
      this.tmpList = null;
    }
  }

  public void setFieldValue(_Fields field, Object value) {
    switch (field) {
    case TMP_LIST:
      if (value == null) {
        unsetTmpList();
      } else {
        setTmpList((List<TestCompose1>)value);
      }
      break;

    }
  }

  public Object getFieldValue(_Fields field) {
    switch (field) {
    case TMP_LIST:
      return getTmpList();

    }
    throw new IllegalStateException();
  }

  /** Returns true if field corresponding to fieldID is set (has been assigned a value) and false otherwise */
  public boolean isSet(_Fields field) {
    if (field == null) {
      throw new IllegalArgumentException();
    }

    switch (field) {
    case TMP_LIST:
      return isSetTmpList();
    }
    throw new IllegalStateException();
  }

  @Override
  public boolean equals(Object that) {
    if (that == null)
      return false;
    if (that instanceof TestCompose3)
      return this.equals((TestCompose3)that);
    return false;
  }

  public boolean equals(TestCompose3 that) {
    if (that == null)
      return false;

    boolean this_present_tmpList = true && this.isSetTmpList();
    boolean that_present_tmpList = true && that.isSetTmpList();
    if (this_present_tmpList || that_present_tmpList) {
      if (!(this_present_tmpList && that_present_tmpList))
        return false;
      if (!this.tmpList.equals(that.tmpList))
        return false;
    }

    return true;
  }

  @Override
  public int hashCode() {
    return 0;
  }

  @Override
  public int compareTo(TestCompose3 other) {
    if (!getClass().equals(other.getClass())) {
      return getClass().getName().compareTo(other.getClass().getName());
    }

    int lastComparison = 0;

    lastComparison = Boolean.valueOf(isSetTmpList()).compareTo(other.isSetTmpList());
    if (lastComparison != 0) {
      return lastComparison;
    }
    if (isSetTmpList()) {
      lastComparison = org.apache.thrift.TBaseHelper.compareTo(this.tmpList, other.tmpList);
      if (lastComparison != 0) {
        return lastComparison;
      }
    }
    return 0;
  }

  public _Fields fieldForId(int fieldId) {
    return _Fields.findByThriftId(fieldId);
  }

  public void read(org.apache.thrift.protocol.TProtocol iprot) throws org.apache.thrift.TException {
    schemes.get(iprot.getScheme()).getScheme().read(iprot, this);
  }

  public void write(org.apache.thrift.protocol.TProtocol oprot) throws org.apache.thrift.TException {
    schemes.get(oprot.getScheme()).getScheme().write(oprot, this);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder("TestCompose3(");
    boolean first = true;

    sb.append("tmpList:");
    if (this.tmpList == null) {
      sb.append("null");
    } else {
      sb.append(this.tmpList);
    }
    first = false;
    sb.append(")");
    return sb.toString();
  }

  public void validate() throws org.apache.thrift.TException {
    // check for required fields
    // check for sub-struct validity
  }

  private void writeObject(java.io.ObjectOutputStream out) throws java.io.IOException {
    try {
      write(new org.apache.thrift.protocol.TCompactProtocol(new org.apache.thrift.transport.TIOStreamTransport(out)));
    } catch (org.apache.thrift.TException te) {
      throw new java.io.IOException(te);
    }
  }

  private void readObject(java.io.ObjectInputStream in) throws java.io.IOException, ClassNotFoundException {
    try {
      read(new org.apache.thrift.protocol.TCompactProtocol(new org.apache.thrift.transport.TIOStreamTransport(in)));
    } catch (org.apache.thrift.TException te) {
      throw new java.io.IOException(te);
    }
  }

  private static class TestCompose3StandardSchemeFactory implements SchemeFactory {
    public TestCompose3StandardScheme getScheme() {
      return new TestCompose3StandardScheme();
    }
  }

  private static class TestCompose3StandardScheme extends StandardScheme<TestCompose3> {

    public void read(org.apache.thrift.protocol.TProtocol iprot, TestCompose3 struct) throws org.apache.thrift.TException {
      org.apache.thrift.protocol.TField schemeField;
      iprot.readStructBegin();
      while (true)
      {
        schemeField = iprot.readFieldBegin();
        if (schemeField.type == org.apache.thrift.protocol.TType.STOP) { 
          break;
        }
        switch (schemeField.id) {
          case 1: // TMP_LIST
            if (schemeField.type == org.apache.thrift.protocol.TType.LIST) {
              {
                org.apache.thrift.protocol.TList _list18 = iprot.readListBegin();
                struct.tmpList = new ArrayList<TestCompose1>(_list18.size);
                for (int _i19 = 0; _i19 < _list18.size; ++_i19)
                {
                  TestCompose1 _elem20;
                  _elem20 = new TestCompose1();
                  _elem20.read(iprot);
                  struct.tmpList.add(_elem20);
                }
                iprot.readListEnd();
              }
              struct.setTmpListIsSet(true);
            } else { 
              org.apache.thrift.protocol.TProtocolUtil.skip(iprot, schemeField.type);
            }
            break;
          default:
            org.apache.thrift.protocol.TProtocolUtil.skip(iprot, schemeField.type);
        }
        iprot.readFieldEnd();
      }
      iprot.readStructEnd();

      // check for required fields of primitive type, which can't be checked in the validate method
      struct.validate();
    }

    public void write(org.apache.thrift.protocol.TProtocol oprot, TestCompose3 struct) throws org.apache.thrift.TException {
      struct.validate();

      oprot.writeStructBegin(STRUCT_DESC);
      if (struct.tmpList != null) {
        oprot.writeFieldBegin(TMP_LIST_FIELD_DESC);
        {
          oprot.writeListBegin(new org.apache.thrift.protocol.TList(org.apache.thrift.protocol.TType.STRUCT, struct.tmpList.size()));
          for (TestCompose1 _iter21 : struct.tmpList)
          {
            _iter21.write(oprot);
          }
          oprot.writeListEnd();
        }
        oprot.writeFieldEnd();
      }
      oprot.writeFieldStop();
      oprot.writeStructEnd();
    }

  }

  private static class TestCompose3TupleSchemeFactory implements SchemeFactory {
    public TestCompose3TupleScheme getScheme() {
      return new TestCompose3TupleScheme();
    }
  }

  private static class TestCompose3TupleScheme extends TupleScheme<TestCompose3> {

    @Override
    public void write(org.apache.thrift.protocol.TProtocol prot, TestCompose3 struct) throws org.apache.thrift.TException {
      TTupleProtocol oprot = (TTupleProtocol) prot;
      BitSet optionals = new BitSet();
      if (struct.isSetTmpList()) {
        optionals.set(0);
      }
      oprot.writeBitSet(optionals, 1);
      if (struct.isSetTmpList()) {
        {
          oprot.writeI32(struct.tmpList.size());
          for (TestCompose1 _iter22 : struct.tmpList)
          {
            _iter22.write(oprot);
          }
        }
      }
    }

    @Override
    public void read(org.apache.thrift.protocol.TProtocol prot, TestCompose3 struct) throws org.apache.thrift.TException {
      TTupleProtocol iprot = (TTupleProtocol) prot;
      BitSet incoming = iprot.readBitSet(1);
      if (incoming.get(0)) {
        {
          org.apache.thrift.protocol.TList _list23 = new org.apache.thrift.protocol.TList(org.apache.thrift.protocol.TType.STRUCT, iprot.readI32());
          struct.tmpList = new ArrayList<TestCompose1>(_list23.size);
          for (int _i24 = 0; _i24 < _list23.size; ++_i24)
          {
            TestCompose1 _elem25;
            _elem25 = new TestCompose1();
            _elem25.read(iprot);
            struct.tmpList.add(_elem25);
          }
        }
        struct.setTmpListIsSet(true);
      }
    }
  }

}
