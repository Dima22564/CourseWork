<template>
  <q-page padding>
    <employees-table :data="employees" />
  </q-page>
</template>

<script>
import EmployeesTable from 'components/tables/EmployeesTable'
export default {
  name: 'EmployeesPage',
  components: { EmployeesTable },
  data: () => {
    return {
      employees: [{}]
    }
  }
}
</script>
