#!/bin/bash
set -e
echo "Test Message"
psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" -f ReleaseScript.sql
psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL
    CREATE USER ecouponuser;
    CREATE DATABASE ecoupon;
    GRANT ALL PRIVILEGES ON DATABASE ecoupon TO ecouponuser;
EOSQL
