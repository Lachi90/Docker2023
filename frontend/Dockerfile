FROM node:20-alpine AS build
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build:production

FROM nginx:alpine
COPY --from=build /app/dist/coding-challenge/ /usr/share/nginx/html
EXPOSE 80
