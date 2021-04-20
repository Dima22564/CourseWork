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
          <q-btn :to="'/new-order/create'" title="Создать заказ, не опираясь на коммерческое предложение" size="sm" color="primary" :icon="icons.mdiPencil" label="новый заказ" />
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
            <q-btn :to="'/new-order/create'" color="secondary" size="sm" label="Просмотр" :loading="loading" />
          </q-td>
        </q-tr>
      </template>
    </q-table>

  </div>
</template>

<script>
import icons from 'src/mixins/icons'
export default {
  name: 'OrdersTable',
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
      columns: [
        { name: 'number', label: '#', align: 'left', field: 'number' },
        { name: 'from', label: 'От', field: 'from' },
        { name: 'validFrom', label: 'Действут с', field: 'validFrom' },
        { name: 'validTo', label: 'Действует по', field: 'validTo' },
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
