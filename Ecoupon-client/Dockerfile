FROM node:alpine AS angularbuild
WORKDIR /ecoupon/client
COPY /package.json .
RUN npm install
COPY . .
RUN npm install -g @angular/cli
RUN ng build --prod

FROM nginx
EXPOSE 3000
COPY ./nginx/default.conf /etc/nginx/conf.d/default.conf
COPY --from=angularbuild /ecoupon/client/dist/Ecoupon-client /usr/share/nginx/html