<template>
  <q-page padding>
    <products-table :data="products" />
  </q-page>
</template>

<script>
import ProductsTable from 'components/tables/ProductsTable'
export default {
  name: 'ProductsPage',
  components: {
    ProductsTable
  },
  async created () {
    try {
      await this.$store.dispatch('product/fetchAll')
    } catch (e) {
      this.$q.notify({
        type: 'negative',
        message: 'Что-то пошло не так( Не удалось загрузить данные.'
      })
    }
  },
  computed: {
    products () {
      return this.$store.state.product.products
    }
  },
  data: () => {
    return {
    }
  }
}
</script>
