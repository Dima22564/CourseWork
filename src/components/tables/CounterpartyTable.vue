<template>
  <div>
    <q-table
      title="Контрагенты"
      :data="data"
      :columns="columns"
      row-key="name"
      binary-state-sort
      :loading="loading"
    >
      <template v-slot:top>
        <div class="flex justify-between flex-center" style="width: 100%">
          <h6 class="q-ma-none">Контрагенты</h6>
          <q-btn v-if="isCreation" @click="createCounterparty = true" size="sm" color="secondary" :icon="icons.mdiPencil" label="создать контрагента" />
          <q-btn v-if="!isCreation" @click="createCounterparty = true" size="sm" color="secondary" :icon="icons.mdiPlus" label="добавить контрагента" />
        </div>
      </template>
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="workName" :props="props">
            {{ props.row.workName }}
            <q-popup-edit
              v-model="props.row.workName"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.workName" dense autofocus counter />
            </q-popup-edit>
          </q-td>

          <q-td key="fullName" :props="props">
            {{ props.row.fullName }}
            <q-popup-edit
              v-model="props.row.fullName"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.fullName" dense autofocus />
            </q-popup-edit>
          </q-td>

          <q-td key="tin" :props="props">
            {{ props.row.tin }}
            <q-popup-edit
              v-model="props.row.tin"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.tin" dense autofocus />
            </q-popup-edit>
          </q-td>

          <q-td key="crtr" :props="props">
            {{ props.row.crtr }}
            <q-popup-edit
              v-model="props.row.crtr"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.crtr" dense autofocus />
            </q-popup-edit>
          </q-td>

          <q-td key="actions" :props="props">
            <q-btn color="primary" size="sm" label="Сохранить" @click="saveChanges(props.row.tin)" :loading="loading" />
            <q-btn class="q-ml-sm" color="secondary" size="sm" label="Просмотр" @click="loadCounterparty(props.row.tin)" :loading="loading" />
          </q-td>
        </q-tr>

      </template>
    </q-table>

    <q-dialog v-model="createCounterparty" persistent>
      <q-card style="width: 700px;">
        <q-card-section class="row items-center justify-between">
          <span class="q-ml-sm text-h6">Создать контрагента</span>
        </q-card-section>

        <CreateCounterpartyPopup />

        <q-card-actions align="right">
          <q-btn flat label="Закрыть" color="primary" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>

  </div>
</template>

<script>
import CreateCounterpartyPopup from 'components/creationElements/CreateCounterpartyPopup'
import icons from 'src/mixins/icons'
export default {
  name: 'CounterpartyTable',
  components: {
    CreateCounterpartyPopup
  },
  mixins: [icons],
  methods: {
    loadCounterparty (tin) {
      this.$router.push('/counterparty/' + tin + '?tab=counterpartyInfo')
    }
  },
  props: {
    data: {
      type: Array,
      default: () => this.data1
    },
    isCreation: {
      type: Boolean,
      default: () => true
    }
  },
  data: () => {
    return {
      loading: false,
      createCounterparty: false,
      data1: [
        { workName: 'JJJJddfdf', fullName: 'RUB', tin: '30101810300000000747', crtr: 18515265 },
        { workName: 'JJJJddfdf', fullName: 'RUB', tin: '30101810300000000747', crtr: 18515265 }
      ],
      columns: [
        { name: 'workName', label: 'Соращенное название', align: 'left', field: 'workName' },
        { name: 'fullName', label: 'Полное название', field: 'fullName' },
        { name: 'tin', label: 'ИНН', field: 'tin' },
        { name: 'crtr', label: 'CRTR', field: 'crtr' },
        { name: 'actions', label: 'Действия', field: 'actions' }
      ]
    }
  }
}
</script>
