<template>
    <section id="basket">
        <h3>
            Basket
            <span v-if="basket.selectedProducts.length > 0" id="empty-all-link">
                (<a href="#" v-on:click="$emit('empty-basket')">removel all items</a>)
            </span>
        </h3>
        <table v-if="basket.selectedProducts.length > 0">

            <tr v-for="(product, i) in basket.selectedProducts" v-bind:class="{ even: i % 2 == 0 }">
                <td>{{product.name}}</td>
                <td class="right-align">
                    <a href="#" v-on:click="$emit('remove-product-from-basket', i)">(remove)</a>
                </td>
            </tr>

            <tr id="total-row">
                <td colspan="2" class="right-align">Total: £{{basket.total}}</td>
            </tr>
        </table>
        <div v-else>
            <h5 id="empty-basket-warn">Basket is empty.</h5>
        </div>
    </section>
</template>

<script>
    export default {
        props: ['basket']
    };
</script>

<style lang="sass" scoped>
    
    #empty-all-link {
        font-size: initial;
    }

    table
    {
        width: 100%;
        border: 1px solid black;
            
        tr {
            border: 1px dotted gray;
                
            &.even
            {
                background-color: azure;
            }

            &#total-row {
                background-color: bisque;
            }

            td.right-align {
                text-align: right;
            }
        }
    }

    #empty-basket-warn {
        text-align: center;
    }
</style>