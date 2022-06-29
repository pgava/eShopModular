FROM nginx

COPY nginx/nginx.local.conf /etc/nginx/nginx.conf
COPY nginx/eshop-api.crt /etc/ssl/certs/api-local.eshopcmc.com.crt
COPY nginx/eshop-api.key /etc/ssl/private/api-local.eshopcmc.com.key
COPY nginx/eshop-www.crt /etc/ssl/certs/www-local.eshopcmc.com.crt
COPY nginx/eshop-www.key /etc/ssl/private/www-local.eshopcmc.com.key

