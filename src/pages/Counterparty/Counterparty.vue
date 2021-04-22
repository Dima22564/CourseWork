<template>
  <q-page padding>
    <h5 class="q-ma-none q-mb-md">Company name (Контрагент)</h5>
    <q-card>
      <q-tabs
        v-model="tab"
        dense
        class="text-grey"
        active-color="primary"
        indicator-color="primary"
        align="justify"
        narrow-indicator
      >
        <q-route-tab :to="{ query: { tab: 'counterpartyInfo' } }" exact replace name="info" label="Основная информация" />
        <q-route-tab :to="{ query: { tab: 'counterpartyContacts' } }" exact replace name="contacts" label="Адреса и контакты" />
        <q-route-tab :to="{ query: { tab: 'counterpartyAccounts' } }" exact replace name="accounts" label="Банковские счета" />
        <q-route-tab :to="{ query: { tab: 'counterpartyPartners' } }" exact replace name="partners" label="Партнеры" />
        <q-route-tab :to="{ query: { tab: 'counterpartyLicenses' } }" exact replace name="licenses" label="Лицензии на алкогольную продукцию" />
      </q-tabs>

      <q-separator />

      <q-tab-panels v-model="tab" animated>
        <q-tab-panel name="info">
          <CounterpartyInfo />
        </q-tab-panel>

        <q-tab-panel name="partners">
          <PartnersTable :is-creation="false" />
        </q-tab-panel>

        <q-tab-panel name="accounts">
          <BankAccountsTable :data="bankAccounts" :is-creation="false" />
        </q-tab-panel>

        <q-tab-panel name="contacts">
          <CounterpartyContacts />
        </q-tab-panel>

        <q-tab-panel name="licenses">
          <AlcoLicensesTable :data="licenses" />
        </q-tab-panel>
      </q-tab-panels>
    </q-card>
  </q-page>
</template>

<script>
import CounterpartyInfo from 'components/CounterpartyInfo'
import CounterpartyContacts from 'components/CounterpartyContacts'
import BankAccountsTable from 'components/tables/BankAccountsTable'
import PartnersTable from 'components/tables/PartnersTable'
import AlcoLicensesTable from 'components/tables/AlcoLicensesTable'
export default {
  components: {
    AlcoLicensesTable,
    PartnersTable,
    CounterpartyInfo,
    CounterpartyContacts,
    BankAccountsTable
  },
  data: () => {
    return {
      tab: 'info',
      companies: ['Company'],
      bankAccounts: [],
      loading: false,
      licenses: []
    }
  },
  methods: {
    save () {
      this.loading = true
    }
  }
}
</script>
