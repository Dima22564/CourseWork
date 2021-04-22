<template>
  <div>
    <q-table
      :data="data"
      :columns="columns"
      row-key="name"
      binary-state-sort
      :loading="loading"
      no-data-label="Нет данных"
    >
      <template v-slot:top>
        <div class="flex justify-between flex-center" style="width: 100%">
          <h6 class="q-ma-none">Заказы</h6>
          <q-btn :to="'/new-order/create'" size="sm" color="primary" :icon="icons.mdiPencil" label="новый заказ">
            <q-tooltip>Создать заказ, не опираясь на коммерческое предложение</q-tooltip>
          </q-btn>
        </div>
      </template>
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="number" :props="props">
            {{ props.row.number }}
          </q-td>

          <q-td key="from" :props="props">
            {{ props.row.from }}
          </q-td>

          <q-td key="validFrom" :props="props">
            {{ props.row.validFrom }}
          </q-td>

          <q-td key="validTo" :props="props">
            {{ props.row.validTo }}
          </q-td>

          <q-td key="company" :props="props">
            {{ props.row.company }}
          </q-td>

          <q-td key="percentOfPayment" :props="props">
            {{ props.row.percentOfPayment }}
          </q-td>

          <q-td key="percentOfShipment" :props="props">
            {{ props.row.percentOfShipment }}
          </q-td>

          <q-td key="amount" :props="props">
            {{ props.row.amount }}
          </q-td>

          <q-td key="currentState" :props="props">
            {{ props.row.currentState }}
          </q-td>

          <q-td key="actions" :props="props">
            <q-btn :to="'/marketing/view/order/' + props.row.orderId" class="q-mr-sm" color="secondary" size="sm" :icon="icons.mdiMagnify" :loading="loading" />
            <q-btn class="q-mr-sm" color="info" size="sm" :icon="icons.mdiAccountSearch" :loading="loading">
              <q-tooltip>Просмотр ответственного лица.</q-tooltip>
            </q-btn>
            <q-btn @click="selectResponsiblePerson = true" class="q-mr-sm" color="purple" size="sm" :icon="icons.mdiSend" :loading="loading">
              <q-tooltip>Отправить на согласование</q-tooltip>
            </q-btn>
            <q-btn color="positive" size="sm" :icon="icons.mdiCheck" :loading="loading">
              <q-tooltip>Подтвердить заказ (заказ готовится к обеспечению)</q-tooltip>
            </q-btn>
          </q-td>
        </q-tr>
      </template>
    </q-table>

    <q-dialog v-model="selectResponsiblePerson" persistent>
      <q-card style="width: 700px; max-width: 80vw;">
        <q-card-section class="row items-center justify-between">
          <span class="q-ma-none text-h6">Отправить на утверждение.</span>
        </q-card-section>

        <select-responsible-person />

        <q-card-actions align="right">
          <q-btn flat label="Закрыть" color="primary" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>
  </div>
</template>

<script>
import icons from 'src/mixins/icons'
import SelectResponsiblePerson from 'components/selectElements/SelectResponsiblePerson'
export default {
  name: 'OrdersTable',
  components: { SelectResponsiblePerson },
  mixins: [icons],
  props: {
    data: {
      type: Array,
      default: () => []
    }
  },
  methods: {
    saveChanges (partnerId) {
    },
    approve (businessProposalId) {
    },
    deny (businessProposalId) {
    },
    cancel (businessProposalId) {
    }
  },
  data: () => {
    return {
      loading: false,
      createAgreement: false,
      selectResponsiblePerson: false,
      columns: [
        { name: 'number', label: '#', align: 'left', field: 'number' },
        { name: 'from', label: 'От', field: 'from' },
        { name: 'validFrom', label: 'Действут с', field: 'validFrom' },
        { name: 'validTo', label: 'Действует по', field: 'validTo' },
        { name: 'company', label: 'Компания', field: 'company' },
        { name: 'percentOfPayment', label: '% оплаты', field: 'percentOfPayment' },
        { name: 'percentOfShipment', label: '% доставки', field: 'percentOfShipment' },
        { name: 'amount', label: 'Сумма', field: 'amount' },
        { name: 'currentState', label: 'Статус', field: 'currentState' },
        { name: 'actions', label: 'Действия', field: 'actions' }
      ]
    }
  }
}
</script>
