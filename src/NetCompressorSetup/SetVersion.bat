@echo off

if "%1"=="" goto end

wscript SetVersion.vbs %1

:end