@echo off
bin\Release\geneuro /create 300 600 10
bin\Release\geneuro /learn
echo.
bin\Release\geneuro /classify tests\0\0.bmp
bin\Release\geneuro /classify tests\1\1.bmp
bin\Release\geneuro /classify tests\2\2.bmp
bin\Release\geneuro /classify tests\3\3.bmp
bin\Release\geneuro /classify tests\4\4.bmp
bin\Release\geneuro /classify tests\5\5.bmp
bin\Release\geneuro /classify tests\6\6.bmp
bin\Release\geneuro /classify tests\7\7.bmp
bin\Release\geneuro /classify tests\8\8.bmp
bin\Release\geneuro /classify tests\9\9.bmp
echo.
bin\Release\geneuro /classify tests\0\bold0.bmp
bin\Release\geneuro /classify tests\1\bold1.bmp
bin\Release\geneuro /classify tests\2\bold2.bmp
bin\Release\geneuro /classify tests\3\bold3.bmp
bin\Release\geneuro /classify tests\4\bold4.bmp
bin\Release\geneuro /classify tests\5\bold5.bmp
bin\Release\geneuro /classify tests\6\bold6.bmp
bin\Release\geneuro /classify tests\7\bold7.bmp
bin\Release\geneuro /classify tests\8\bold8.bmp
bin\Release\geneuro /classify tests\9\bold9.bmp
