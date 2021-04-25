FROM node:15.14.0-alpine3.10 AS builder
WORKDIR /scm
COPY . .
RUN npm i
RUN npm run build --prod

FROM nginx:1.19.10-alpine
COPY --from=builder /scm/dist/scm/ /usr/share/nginx/html