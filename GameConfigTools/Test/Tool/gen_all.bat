@echo off

rd /s /q gen-csharp
rd /s /q gen-java

FOR %%e IN (*.thrift) DO (
  echo gen c# %%e
  call thrift-0.9.1.exe --gen csharp %%e
  call thrift-0.9.1.exe --gen java %%e
)
pause