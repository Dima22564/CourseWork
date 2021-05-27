<template>
  <q-page padding>
    <CounterpartyTable :data="counterparties" is-creation />
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
  async created () {
    try {
      await this.$store.dispatch('counterparty/fetchAll')
    } catch (e) {
      this.$q.notify({
        type: 'negative',
        message: 'Что-то пошло не так( Не удалось загрузить данные.'
      })
    }
  },
  computed: {
    counterparties () {
      return this.$store.state.counterparty.counterparties
    }
  },
  data: () => {
    return {
    }
  }
}
</script>
