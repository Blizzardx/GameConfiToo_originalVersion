namespace csharp Config
namespace java com.kaixin001.hero.client.upload.tools.auto


struct TestInt
{
  1: i32 id
}
struct Testfloat
{
  1: double id
}
struct TestString
{
  1: string id
}
struct TestBool
{
  1: bool id
}
struct TestByte
{
1: byte id
}
struct TesetCompose
{
   1: i32 id
   2: double doubleId
   3: string stringId
   4: bool boolId
   5: byte byteId
}
struct TestCompose1
{
	1: list<i32> tmpList	
}
struct TestCompose2
{
	1: map<i32,i32> tmpMap
}
struct TestCompose3
{
	1: list<TestCompose1> tmpList
}
struct TestCompose4
{
	1: map<i32,TestCompose3> tmpMap
}
struct ListList
{
	1:list<list<i32>> tmpList
}
struct Listmap
{
	1:list<map<i32,i32>> tmpList
}
struct Listset
{
	1:list<set<i32>> tmpList
}
struct Maplist
{
	1:map<i32,list<i32>> tmpMap
}
struct MapMap
{
	1:map<i32,map<i32,i32>> tmpMap
}
struct Mapset
{
	1:map<i32,set<i32>> tmpMap
}