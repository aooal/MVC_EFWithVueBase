import { createApp } from 'vue';
import App from './App.vue';
import { createRouter, createWebHistory } from 'vue-router';
import Home from './Home.vue';
import Users from './Users.vue';
import PrimeVue from 'primevue/config';
import Button from 'primevue/button';
import Dialog from 'primevue/dialog';
import 'primevue/resources/themes/saga-blue/theme.css'; // 確保這些路徑是正確的
import 'primevue/resources/primevue.min.css';
import 'primeicons/primeicons.css';

const routes = [
    { path: '/', component: Home },
    { path: '/users', component: Users }, // 路徑應為小寫
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

const app = createApp(App); // 創建 Vue 應用實例

app.use(PrimeVue); // 使用 PrimeVue 插件
app.component('Button', Button); 
app.component('Dialog', Dialog);
app.use(router); // 使用路由
app.mount('#app'); // 掛載到 #app 元素
