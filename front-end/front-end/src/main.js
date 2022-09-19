import Vue from 'vue';
import App from './app.vue';
import router from './router/router';
import vuetify from './plugins/vuetify';
import './assets/styles.css';

import { VueMaskDirective } from 'v-mask'
Vue.directive('mask', VueMaskDirective);
Vue.config.productionTip = false;


new Vue({
  router,
  vuetify,
  render: h => h(App)
}).$mount('#app');
