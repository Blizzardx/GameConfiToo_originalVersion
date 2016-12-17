using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Message;
using Config;

namespace GameConfigTools.Test
{
    class ThriftFormateTest
    {
        public void Main()
        {
            PackDataStruct data = new PackDataStruct();
            data.m_ElemList = new List<PackDataElement>();

            PackDataElement elem1 = new PackDataElement();
            elem1.m_Id = 1;
            elem1.m_strName = "tmpList";
            elem1.m_Type = PackDataElementType.List;
            data.m_ElemList.Add(elem1);
            var list = new List<PackDataElement>();
            elem1.m_Value = list;
            for (int i = 0; i < 100; ++i)
            {
                PackDataStruct subElem = new PackDataStruct();
                subElem.m_ElemList = new List<PackDataElement>();
                PackDataElement elem2 = new PackDataElement();
                elem2.m_Id = 1;
                elem2.m_strName = "tmpList";
                elem2.m_Type = PackDataElementType.List;
                subElem.m_ElemList.Add(elem2);
                var subList = new List<PackDataElement>();
                elem2.m_Value = subList;
                for (int j = 0; j < 100; ++j)
                {
                    PackDataElement subsubElem = new PackDataElement();
                    subsubElem.m_Type = PackDataElementType.I32;
                    subsubElem.m_Value = j + 1;
                    subList.Add(subsubElem);
                }

                var tmpElem = new PackDataElement();
                tmpElem.m_Type = PackDataElementType.Struct;
                tmpElem.m_Value = subElem;
                tmpElem.m_strName = "TestCompose1";
                list.Add(tmpElem);
            }

            var packer = new Packer_Thrift();
            var bytes = packer.DoPack(data);
            TestCompose3 realData = new TestCompose3();
             ThriftSerialize.DeSerialize(realData, bytes);
            int a = 0;
        }

        private void GetStructInfo(PackDataStruct data)
        {
            for (int i = 0; i < data.m_ElemList.Count; ++i)
            {
                var elem = data.m_ElemList[i];
                switch (elem.m_Type)
                {
                    case PackDataElementType.Bool:
                        break;
                    case PackDataElementType.Byte:
                        break;
                    case PackDataElementType.Double:
                        break;
                    case PackDataElementType.I16:
                        break;
                    case PackDataElementType.I32:
                        break;
                    case PackDataElementType.I64:
                        break;
                    case PackDataElementType.String:
                        break;
                    case PackDataElementType.Struct:
                        break;
                    case PackDataElementType.Map:
                        break;
                    case PackDataElementType.Set:
                        break;
                    case PackDataElementType.List:
                        break;
                    default:
                        {
                            throw new Exception("Error type");
                        }
                }
            }
        }
        public void Test1()
        {
            
        }
        public void Main2()
        {
            TestInt testInt = new TestInt();
            testInt.Id = 3;
            var bytes = ThriftSerialize.Serialize(testInt);
            File.WriteAllBytes("testInt.bytes", bytes);
            byte[] array = new byte[]{21,};
            TestString testString = new TestString();
            testString.Id = "0";
            bytes = ThriftSerialize.Serialize(testString);
            File.WriteAllBytes("testString.bytes", bytes);

            Testfloat testFloat = new Testfloat();
            testFloat.Id = 0.0f;
            bytes = ThriftSerialize.Serialize(testFloat);
            File.WriteAllBytes("testFloat.bytes", bytes);

            TestBool testBool = new TestBool();
            testBool.Id = true;
            bytes = ThriftSerialize.Serialize(testBool);
            File.WriteAllBytes("testBool.bytes", bytes);

            TestByte testByte = new TestByte();
            testByte.Id = 0;
            bytes = ThriftSerialize.Serialize(testByte);
            File.WriteAllBytes("testByte.bytes", bytes);

            TesetCompose testCompose = new TesetCompose();
            testCompose.Id = 0;
            testCompose.StringId = "0";
            testCompose.BoolId = true;
            testCompose.ByteId = 0;
            testCompose.DoubleId = 0.0f;
            bytes = ThriftSerialize.Serialize(testCompose);
            File.WriteAllBytes("testCompose.bytes", bytes);

            TestCompose1 testCompose1 = new TestCompose1();
            testCompose1.TmpList = new List<int>(){1,2,3,4,5};
            bytes = ThriftSerialize.Serialize(testCompose1);
            File.WriteAllBytes("testCompose1.bytes", bytes);

            TestCompose2 testCompose2 = new TestCompose2();
            testCompose2.TmpMap = new Dictionary<int, int>();
            testCompose2.TmpMap.Add(0, 0);
            testCompose2.TmpMap.Add(1, 1);
            testCompose2.TmpMap.Add(2, 2);
            testCompose2.TmpMap.Add(3, 3);
            testCompose2.TmpMap.Add(4, 4);
            testCompose2.TmpMap.Add(5, 5);
            bytes = ThriftSerialize.Serialize(testCompose2);
            File.WriteAllBytes("testCompose2.bytes", bytes);

            TestCompose3 testCompose3 = new TestCompose3();
            testCompose3.TmpList = new List<TestCompose1>() { testCompose1, testCompose1, testCompose1 };
            bytes = ThriftSerialize.Serialize(testCompose3);
            File.WriteAllBytes("testCompose3.bytes", bytes);

            TestCompose4 testCompose4 = new TestCompose4();
            testCompose4.TmpMap = new Dictionary<int, TestCompose3>();
            testCompose4.TmpMap.Add(0, testCompose3);
            testCompose4.TmpMap.Add(1, testCompose3);
            testCompose4.TmpMap.Add(2, testCompose3);

            bytes = ThriftSerialize.Serialize(testCompose4);
            File.WriteAllBytes("testCompose4.bytes", bytes);
        }
    }
}