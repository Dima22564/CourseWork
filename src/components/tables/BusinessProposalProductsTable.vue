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
          <h6 class="q-ma-none">Товары</h6>
          <q-btn @click="addPartner = true" size="sm" color="secondary" :icon="icons.mdiPlus">
            <q-tooltip>Добавить товар</q-tooltip>
          </q-btn>
        </div>
      </template>
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="productId" :props="props">
            {{ props.row.productId }}
          </q-td>

          <q-td key="code" :props="props">
            {{ props.row.code }}
          </q-td>

          <q-td key="workName" :props="props">
            {{ props.row.workName }}
          </q-td>

          <q-td key="vat" :props="props">
            {{ props.row.vat }} %
          </q-td>

          <q-td key="quantity" :props="props">
            {{ props.row.quantity }}
          </q-td>

          <q-td key="price" :props="props">
            {{ props.row.price }}
          </q-td>

          <q-td key="amount" :props="props">
            {{ props.row.amount }}
          </q-td>

          <q-td key="actions" :props="props">
            <q-btn color="primary" size="sm" label="Сохранить" @click="saveChanges(props.row.partnerId)" :loading="loading" />
          </q-td>
        </q-tr>
      </template>
    </q-table>

    <q-dialog v-model="createPartner" persistent>
      <q-card style="width: 700px;">
        <q-card-section class="row items-center justify-between">
          <span class="q-ma-none text-h6">Создание партнера.</span>
        </q-card-section>

        <AddBankAccountPopup />

        <q-card-actions align="right">
          <q-btn flat label="Закрыть" color="primary" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>
  </div>
</template>

<script>
import icons from 'src/mixins/icons'

export default {
  name: 'BusinessProposalProductsTable',
  mixins: [icons],
  props: {
    data: {
      type: Array,
      default: () => []
    }
  },
  data: () => {
    return {
      loading: false,
      addPartner: false,
      createPartner: false,
      columns: [
        { name: 'productId', label: '#', align: 'left', field: 'productId' },
        { name: 'code', label: 'Код', field: 'code' },
        { name: 'workName', label: 'Название', field: 'workName' },
        { name: 'vat', label: 'НДС', field: 'vat' },
        { name: 'quantity', label: 'Кол-во', field: 'quantity' },
        { name: 'price', label: 'Цена за ед.', field: 'price' },
        { name: 'amount', label: 'Стоимость', field: 'amount' },
        { name: 'actions', label: 'Действия', field: 'actions' }
      ]
    }
  }
}
</script>
