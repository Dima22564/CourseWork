<template>
  <q-page padding>
    <business-proposals-table :loading="loading" :data="businessProposals" />
  </q-page>
</template>

<script>
import BusinessProposalsTable from 'components/tables/BusinessProposalsTable'
export default {
  name: 'AllBusinessProposalsPage',
  components: { BusinessProposalsTable },
  data: () => {
    return {
      loading: false
    }
  },
  computed: {
    businessProposals () {
      return this.$store.state.businessProposal.businessProposals
    }
  },
  async mounted () {
    this.loading = true
    try {
      await this.$store.dispatch('businessProposal/fetchAll')
    } catch (e) {
      this.$q.notify({
        type: 'negative',
        message: 'Что-то пошло не так( Не удалось загрузить данные.'
      })
    } finally {
      this.loading = false
    }
  }
}
</script>
