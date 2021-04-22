<template>
  <q-page padding>
    <business-proposals-table :data="businessProposals" />
  </q-page>
</template>

<script>
import BusinessProposalsTable from 'components/tables/BusinessProposalsTable'
export default {
  name: 'AllBusinessProposalsPage',
  components: { BusinessProposalsTable },
  data: () => {
    return {
      businessProposals: [{}]
    }
  }
}
</script>
