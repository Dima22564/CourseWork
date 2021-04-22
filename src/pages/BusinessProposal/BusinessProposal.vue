<template>
  <q-page padding>
    <q-page-sticky style="z-index: 555" position="bottom-right" :offset="[18, 18]">
      <q-fab color="amber" text-color="black" icon="keyboard_arrow_left" direction="left">
        <q-fab-action color="primary" @click="onClick" :icon="icons.mdiPlus">
          <q-tooltip>Добавить товар</q-tooltip>
        </q-fab-action>
        <q-fab-action color="positive" text-color="white" @click="onClick" :icon="icons.mdiCheck">
          <q-tooltip>Подтвердить КП</q-tooltip>
        </q-fab-action>
        <q-fab-action color="negative" text-color="white" @click="onClick" :icon="icons.mdiCloseOctagon">
          <q-tooltip>Аннулировать действующее КП</q-tooltip>
        </q-fab-action>
        <q-fab-action color="negative" text-color="white" @click="onClick" :icon="icons.mdiCancel">
          <q-tooltip>Отклонить КП</q-tooltip>
        </q-fab-action>
        <q-fab-action color="purple" text-color="white" @click="onClick" :icon="icons.mdiSend">
          <q-tooltip>Отправить на согласование</q-tooltip>
        </q-fab-action>
      </q-fab>
    </q-page-sticky>
    <div class="q-mb-md flex items-center justify-between">
      <h5 class="q-ma-none">Number from date (коммерческое предложение)</h5>
      <div>
        <q-chip color="positive" text-color="white">
          Действует
        </q-chip>
        <q-chip color="accent" text-color="white">
          Не согласовано
        </q-chip>
        <q-chip color="negative" text-color="white">
          Отклонено
        </q-chip>
        <q-chip color="negative" text-color="white">
          Не действует
        </q-chip>
        <q-chip color="primary" text-color="white">
          Отправлено на согласование
        </q-chip>
      </div>

      <q-btn size="md" color="primary" label="заказ" :icon="icons.mdiPencil">
        <q-tooltip>Создать новый заказ на основе данного коммерческого предложения</q-tooltip>
      </q-btn>
    </div>
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
        <q-route-tab :to="{ query: { tab: 'businessProposalInfo' } }" exact replace name="info" label="Основная информация" />
        <q-route-tab :to="{ query: { tab: 'businessProposalProducts' } }" exact replace name="products" label="Товары" />
      </q-tabs>

      <q-separator />

      <q-tab-panels v-model="tab" animated>
        <q-tab-panel name="info">
          <business-proposal-info :business-proposal="businessProposal" />
        </q-tab-panel>

        <q-tab-panel name="products">
          <business-proposal-products-table :data="businessProposal.products" :is-creation="false" />
        </q-tab-panel>
      </q-tab-panels>
    </q-card>
  </q-page>
</template>

<script>
import BusinessProposalInfo from 'components/BusinessProposalInfo'
import BusinessProposalProductsTable from 'components/tables/BusinessProposalProductsTable'
import icons from 'src/mixins/icons'
export default {
  name: 'BusinessProposalPage',
  components: { BusinessProposalProductsTable, BusinessProposalInfo },
  mixins: [icons],
  data: () => {
    return {
      tab: 'info',
      loading: false,
      businessProposal: {
        products: [{}]
      }
    }
  }
}
</script>
