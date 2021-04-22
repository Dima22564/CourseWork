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
  data: () => {
    return {
      agreements: [{}]
    }
  }
}
</script>
