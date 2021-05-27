<template>
  <q-page padding>
    <agreements-table :data="agreements" />
  </q-page>
</template>

<script>
import AgreementsTable from 'components/tables/AgreementsTable'
export default {
  name: 'AllAgreementsPage',
  components: { AgreementsTable },
  computed: {
    agreements () {
      return this.$store.state.agreement.agreements
    }
  },
  async mounted () {
    this.loading = true
    try {
      await this.$store.dispatch('agreement/fetchAll')
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
