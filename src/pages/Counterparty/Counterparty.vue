<template>
  <q-page padding>
    <h5 v-if="counterparty !== null" class="q-ma-none q-mb-md">{{ counterparty.name.workName }} (Контрагент)</h5>
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
          <CounterpartyInfo
            :counterparty="counterparty"
            v-if="counterparty !== null"
          />
        </q-tab-panel>

        <q-tab-panel name="partners">
          <PartnersTable :is-creation="false" />
        </q-tab-panel>

        <q-tab-panel name="accounts">
          <BankAccountsTable
            v-if="counterparty !== null"
            :company-name="counterparty.name.workName"
            :data="bankAccounts.filter(x => x.company.tin === Number($route.params.tin))"
          />
        </q-tab-panel>

        <q-tab-panel name="contacts">
          <CounterpartyContacts
            :counterparty="counterparty"
            v-if="counterparty !== null"
          />
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
      loading: false,
      licenses: [],
      counterparty: null
    }
  },
  computed: {
    bankAccounts () {
      return this.$store.state.bankAccount.bankAccounts
    }
  },
  async mounted () {
    try {
      const res = await this.$store.dispatch('counterparty/getById', this.$route.params.tin)
      this.counterparty = res.data
      if (this.bankAccounts.length === 0) {
        await this.$store.dispatch('bankAccount/fetchAll')
      }
    } catch (e) {
      this.$q.notify({
        type: 'negative',
        message: e.response.data
      })
    }
  }
}
</script>
