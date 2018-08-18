<template>
    <div id="app-container">
        <products-list v-bind:products="products" v-on:add-product-to-basket="addProductToBasket" />
        <basket v-bind:basket="basket" v-on:remove-product-from-basket="removeProductFromBasket"/>
    </div>
</template>

<script>

    const axios = require('axios');

    export default {
        data () {
            return {
                products: [],
                basket: {
                    total: 0,
                    selectedProducts:[]
                }
            };
        },
        methods: {
            addProductToBasket: function (product) {
                this.basket.selectedProducts.push(product);
            },
            removeProductFromBasket: function (i) {
                this.basket.selectedProducts.splice(i, 1);
            } 
        },
        mounted () {
            axios
                .get('/api/products')
                .then(response => this.products = response && response.data ? response.data : []);
        },
        watch: {
            'basket.selectedProducts': function (oldBasket, newBasket) {

                axios
                    .post('/api/basket-total',
                    {
                        selectedProductsIdentifiers: this.basket.selectedProducts.map(function (p) { return p.identifier; })
                    })
                    .then(response => this.basket.total = response !== null && response.data ? response.data : 0);

            }
        }
    };

</script>

<style lang="sass">

    body {
        width: 500px;
        margin: 0 auto;

        #app-container {
            width: 100%;
        }
    }

</style>