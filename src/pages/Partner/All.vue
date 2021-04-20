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
  data: () => {
    return {
      loading: false,
      partners: [{}]
    }
  }
}
</script>
