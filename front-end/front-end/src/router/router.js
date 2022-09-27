import Vue from 'vue';
import VueRouter from 'vue-router';
import CreateCategoryPage from '../views/create-category.vue';
import CreateBoatPage from '../views/create-boat.vue';
import CreateLessorPage from '../views/create-lessor.vue';
import LessorPage from '../views/Lessor-page.vue';
import CategoryPage from '../views/category-page';
import BookingPage from '../views/booking-page';
import ReturnPage from '../views/return-page';
Vue.use(VueRouter);


const routes = [
  {
    path: '/',
    component: LessorPage
  },
  {
    path:'/booking',
    component:BookingPage
  },
  {
    path: '/category',
    component: CategoryPage
  },
  {
    path: '/createCategory',
    component: CreateCategoryPage
  },
  {
    path: '/createBoat',
    component: CreateBoatPage
  },
  {
    path: '/createLessor',
    component: CreateLessorPage
  },
  {
    path:'/returnPage',
    component: ReturnPage
  }
];


const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
});


export default router;
