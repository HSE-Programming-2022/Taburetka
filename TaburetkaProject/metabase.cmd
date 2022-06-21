%1@mshta vbscript:Execute("CreateObject(""Wscript.Shell"").Run """"""%~f0"""" :"",0:Close()")& exit/b
@echo off
cd Metabase
timeout  /t 01
java -jar metabase.jar