<template>
    <section>
        <h3>Products</h3>
        <ul>
            <li v-for="(product, i) in products" :key="product.identifier" v-bind:class="{ even: i % 2 == 0 }">
                <span class="prod-name">{{product.name}}</span>
                <span class="prod-price">£{{product.price}}</span>
                <span class="prod-add">
                    <input type="button" v-on:click="$emit('add-product-to-basket', product)" value="Add to basket" />
                </span>
            </li>
        </ul>
    </section>
</template>

<script>
    export default {
        props: ['products']
    }
</script>

<style lang="sass" scoped>

    ul {
        list-style-type: none;

        li {
            margin-bottom: 15px;

            span {
                display: inline-block;
            }

            .prod-name {
                width: 150px;
            }
            .prod-price {
                width: 80px;
            }
            .prod-add {
                text-align: right;
            }
        }
    }

</style>