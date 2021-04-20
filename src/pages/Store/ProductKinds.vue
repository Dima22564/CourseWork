<template>
  <q-page padding>
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
          <h6 class="q-ma-none">Категории товаров</h6>
          <q-btn @click="addProductKind = true" size="sm" color="secondary" :icon="icons.mdiPencil" label="создать категорию" />
        </div>
      </template>
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="id" :props="props">
            {{ props.row.id }}
          </q-td>

          <q-td key="name" :props="props">
            {{ props.row.name }}
            <q-popup-edit
              v-model="props.row.name"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.name" dense autofocus />
            </q-popup-edit>
          </q-td>

          <q-td key="details" :props="props">
            {{ props.row.details }}
            <q-popup-edit
              v-model="props.row.details"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.details" dense autofocus />
            </q-popup-edit>
          </q-td>

          <q-td key="type" :props="props">
            {{ props.row.type }}
            <q-popup-edit
              v-model="props.row.type"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-select filled v-model="props.row.type" :options="types" label="Filled" />
            </q-popup-edit>
          </q-td>

          <q-td key="vat" :props="props">
            {{ props.row.vat }}
            <q-popup-edit
              v-model="props.row.vat"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-select filled v-model="props.row.vat" :options="vatRates" label="Filled" />
            </q-popup-edit>
          </q-td>

          <q-td key="actions" :props="props">
            <q-btn color="primary" size="sm" label="Сохранить" @click="saveChanges(props.row.id)" :loading="loading" />
          </q-td>
        </q-tr>
      </template>
    </q-table>

    <q-dialog v-model="addProductKind" persistent>
      <q-card style="width: 700px;">
        <q-card-section class="row items-center justify-between">
          <span class="q-ma-none text-h6">Создать категорию.</span>
        </q-card-section>

        <CreateProductKindPopup />

        <q-card-actions align="right">
          <q-btn flat label="Закрыть" color="primary" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>

  </q-page>
</template>

<script>
import icons from 'src/mixins/icons'
import CreateProductKindPopup from 'components/creationElements/CreateProductKindPopup'
export default {
  components: { CreateProductKindPopup },
  name: 'ProductKinds',
  mixins: [icons],
  methods: {
    saveChanges (unitId) {
    }
  },
  data: () => {
    return {
      loading: false,
      addProductKind: false,
      vatRates: [0, 10, 18, 20],
      types: [],
      data: [],
      columns: [
        { name: 'id', label: '#', align: 'left', field: 'id' },
        { name: 'name', label: 'Полное название', field: 'name' },
        { name: 'details', label: 'Примечания', field: 'details' },
        { name: 'vat', label: 'Ставка НДС на категорию', field: 'vat' },
        { name: 'type', label: 'Тип продукта', field: 'type' },
        { name: 'actions', label: 'Действия', field: 'actions' }
      ]
    }
  }
}
</script>
