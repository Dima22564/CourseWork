<template>
  <q-page padding>
    <BankAccountsTable :data="data" />
  </q-page>
</template>

<script>
import BankAccountsTable from 'components/tables/BankAccountsTable'
export default {
  name: 'PageBankAccountAll',
  components: {
    BankAccountsTable
  },
  data: () => {
    return {
      data: [
        { name: 'JJJJddfdf', currency: 'RUB', accountNumber: '30101810300000000747', bank: 'dfgdfhg', bic: 18515265, company: 'Company name' },
        { name: 'JJJJddfdf', currency: 'RUB', accountNumber: '30101810300000000747', bank: 'dfgdfhg', bic: 18515265, company: 'Company name' }
      ]
    }
  }
}
</script>
