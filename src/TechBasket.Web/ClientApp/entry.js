import Vue from 'vue';
import App from './App.vue';

import ProductsList from './components/ProductsList';
import BasketComponent from './components/Basket';

var app = new Vue({
    el: '#app',
    components: {
        'products-list': ProductsList,
        'basket': BasketComponent
    },
    ...App
});