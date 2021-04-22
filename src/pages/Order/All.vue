<template>
  <q-page padding>
    <orders-table :data="orders" />
  </q-page>
</template>

<script>
import OrdersTable from 'components/tables/OrdersTable'
export default {
  name: 'AllOrdersPage',
  components: { OrdersTable },
  data: () => {
    return {
      orders: [{}]
    }
  }
}
</script>
