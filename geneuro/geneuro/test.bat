@echo off
bin\Release\geneuro /create 300 600 10
bin\Release\geneuro /learn data
echo.
bin\Release\geneuro /classify tests\0.bmp
bin\Release\geneuro /classify tests\1.bmp
bin\Release\geneuro /classify tests\2.bmp
bin\Release\geneuro /classify tests\3.bmp
bin\Release\geneuro /classify tests\4.bmp
bin\Release\geneuro /classify tests\5.bmp
bin\Release\geneuro /classify tests\6.bmp
bin\Release\geneuro /classify tests\7.bmp
bin\Release\geneuro /classify tests\8.bmp
bin\Release\geneuro /classify tests\9.bmp
