<template>
  <q-page padding>
    <CounterpartyTable :data="data" is-creation />
  </q-page>
</template>

<script>
import CounterpartyTable from 'components/tables/CounterpartyTable'
export default {
  name: 'PageCounterparty',
  methods: {
    loadCounterparty (tin) {
      this.$router.push('/counterparty/' + tin + '?tab=counterpartyInfo')
    }
  },
  components: {
    CounterpartyTable
  },
  data: () => {
    return {
      data: [
        { workName: 'JJJJddfdf', fullName: 'RUB', tin: '30101810300000000747', crtr: 18515265 },
        { workName: 'JJJJddfdf', fullName: 'RUB', tin: '30101810300000000747', crtr: 18515265 }
      ]
    }
  }
}
</script>
