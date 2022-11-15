@echo off
setlocal
set PGPASSWORD=%1
set PATH_PSQL="C:\Program Files\PostgreSQL\15\bin"
set PATH_SQL_COMMAND="C:\01_Home\SQL"
set PATH_LOG="C:\01_Home\SQL\__Log"

rem Input and output options:
rem   -a, --echo-all           echo all input from script
rem   -b, --echo-errors        echo failed commands
rem   -e, --echo-queries       echo commands sent to server

%PATH_PSQL%\psql.exe -h localhost -U postgres -d postgres -f %PATH_SQL_COMMAND%\01_Create_database.sql    -a -b -e   -o %PATH_LOG%\01_Create_database.log
%PATH_PSQL%\psql.exe -h localhost -U postgres -d     ebay -f %PATH_SQL_COMMAND%\02_Create_products.sql    -a -b -e   -o %PATH_LOG%\02_Create_products.log
%PATH_PSQL%\psql.exe -h localhost -U postgres -d     ebay -f %PATH_SQL_COMMAND%\03_Create_customers.sql   -a -b -e   -o %PATH_LOG%\03_Create_customers.log
%PATH_PSQL%\psql.exe -h localhost -U postgres -d     ebay -f %PATH_SQL_COMMAND%\04_Create_orders.sql      -a -b -e   -o %PATH_LOG%\04_Create_orders.log
%PATH_PSQL%\psql.exe -h localhost -U postgres -d     ebay -f %PATH_SQL_COMMAND%\05_Create_order_items.sql -a -b -e   -o %PATH_LOG%\05_Create_order_items.log

pause
endlocal