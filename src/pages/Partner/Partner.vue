<template>
  <q-page padding>
    <div class="flex justify-between flex-center q-mb-md">
      <h4 class="q-ma-none q-mb-md">{{ partner.fullName }}</h4>
      <div class="q-ml-auto">
        <q-btn
          @click="createBusinessProposalPopup = true"
          color="primary"
          class="q-mr-sm"
          size="md"
          label="Сделать комммерческое предложение"
        />
        <q-btn
          @click="createBusinessProposalPopup = true"
          color="purple"
          class="q-mr-sm"
          size="md"
          label="Создать заказ"
          title="Создать заказ, не опираясь на коммерческое предложение."
        />
      </div>
    </div>

    <q-card>
      <q-tabs
        v-model="tab"
        dense
        class="text-black text-weight-bold"
        active-color="primary"
        indicator-color="primary"
        align="justify"
        narrow-indicator
      >
        <q-route-tab :to="{ query: { tab: 'partnerInfo' } }" exact replace name="partnerInfo" label="Основная информация" />
        <q-route-tab :to="{ query: { tab: 'partnerCounterparty' } }" exact replace name="partnerCounterparty" label="Контрагенты" />
        <q-route-tab :to="{ query: { tab: 'contactPeople' } }" exact replace name="contactPeople" label="Контактные лица" />
        <q-route-tab :to="{ query: { tab: 'agreements' } }" exact replace name="agreements" label="Соглашения" />
        <q-route-tab :to="{ query: { tab: 'businessProposal' } }" exact replace name="businessProposal" label="Коммерческие предложения" />
        <q-route-tab :to="{ query: { tab: 'clientOrders' } }" exact replace name="clientOrders" label="Заказы" />
      </q-tabs>

      <q-separator />

      <q-tab-panels v-model="tab" animated>
        <q-tab-panel name="partnerInfo">
          <PartnerInfo :partner="partner" />
        </q-tab-panel>

        <q-tab-panel name="partnerCounterparty">
          <CounterpartyTable :data="partner.counterparties" :is-creation="false" />
        </q-tab-panel>

        <q-tab-panel name="contactPeople">
          <ContactPeopleTable :data="partner.contactPeople" is-show-add-contact-person-btn/>
        </q-tab-panel>

        <q-tab-panel name="agreements">
          <AgreementsTable :data="partner.agreements" />
        </q-tab-panel>

        <q-tab-panel name="businessProposal">
          <business-proposals-table :data="partner.businessProposals" />
        </q-tab-panel>

        <q-tab-panel name="clientOrders">
          <orders-table :data="partner.orders" />
        </q-tab-panel>
      </q-tab-panels>
    </q-card>
  </q-page>
</template>

<script>
import PartnerInfo from 'components/PartnerInfo'
import CounterpartyTable from 'components/tables/CounterpartyTable'
import ContactPeopleTable from 'components/tables/ContactPeopleTable'
import AgreementsTable from 'components/tables/AgreementsTable'
import BusinessProposalsTable from 'components/tables/BusinessProposalsTable'
import OrdersTable from 'components/tables/OrdersTable'
export default {
  components: { OrdersTable, BusinessProposalsTable, AgreementsTable, ContactPeopleTable, CounterpartyTable, PartnerInfo },
  data: () => {
    return {
      tab: 'partnerInfo',
      companies: ['Company'],
      bankAccounts: [],
      createBusinessProposalPopup: false,
      loading: false,
      partner: {
        fullName: 'Some loooooong company name',
        workName: 'WorkName',
        phone: 124866532,
        email: 'Eamil@text.com',
        legalAddress: 'Address',
        physicalAddress: 'Address 2',
        contactPeople: [],
        counterparties: [],
        agreements: [{}],
        businessProposals: [{}],
        orders: [{}]
      }
    }
  }
}
</script>
