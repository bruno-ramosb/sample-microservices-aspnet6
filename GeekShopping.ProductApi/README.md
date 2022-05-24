# Api de produtos

Para iniciar banco de dados postgres via docker
```
docker run --name dev-postgres --network=postgres-network -e "POSTGRES_PASSWORD=development" -p 5432:5432 -v /home/bruno/desenvolvimento/pgsql:/var/lib/postgresql/data -d postgres
```