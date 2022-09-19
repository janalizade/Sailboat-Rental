import Vue from 'vue';
import VueRouter from 'vue-router';
import HomePage from '../views/home-page.vue';
import CreateBudgetPage from '../views/create-budget-page.vue';
import CreateCategoryPage from '../views/create-category.vue';
import CreateBoatPage from '../views/create-boat.vue';

Vue.use(VueRouter);


const routes = [
  {
    path: '/',
    component: HomePage
  },
  {
    path: '/create',
    component: CreateBudgetPage
  },
  {
    path: '/createCategory',
    component: CreateCategoryPage
  },
  {
    path: '/createBoat',
    component: CreateBoatPage
  }
];


const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
});


export default router;
