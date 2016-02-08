@echo off
%~dp0/bin/Release/geneuro.exe /create 300 600 10
%~dp0/bin/Release/geneuro /learn data
echo.
%~dp0/bin/Release/geneuro /classify tests/0.bmp
%~dp0/bin/Release/geneuro /classify tests/1.bmp
%~dp0/bin/Release/geneuro /classify tests/2.bmp
%~dp0/bin/Release/geneuro /classify tests/3.bmp
%~dp0/bin/Release/geneuro /classify tests/4.bmp
%~dp0/bin/Release/geneuro /classify tests/5.bmp
%~dp0/bin/Release/geneuro /classify tests/6.bmp
%~dp0/bin/Release/geneuro /classify tests/7.bmp
%~dp0/bin/Release/geneuro /classify tests/8.bmp
%~dp0/bin/Release/geneuro /classify tests/9.bmp
