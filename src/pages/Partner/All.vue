<template>
  <q-page padding>
    <PartnersTable :data="partners" />
  </q-page>
</template>

<script>
import PartnersTable from 'components/tables/PartnersTable'
export default {
  name: 'PagePartnersAll',
  components: { PartnersTable },
  methods: {
    saveChanges (code) {
      this.loading = true
      // /currency/change/code
    }
  },
  async mounted () {
    try {
      await this.$store.dispatch('partner/fetchAll')
    } catch (e) {
      this.$q.notify({
        type: 'negative',
        message: 'Не удалось загрузить данные'
      })
    }
  },
  computed: {
    partners () {
      return this.$store.state.partner.partners
    }
  },
  data: () => {
    return {
      loading: false
    }
  }
}
</script>
